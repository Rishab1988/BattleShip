namespace BattleShipGame
{
    public class BattleCell
    {
        private static int _hitCount;

        public int Column { get; set; }
        public int Row { get; set; }
        public bool HasShip => Ship != null;

        public HitAcknowledgement Hit()
        {
            if (!HasShip)
                return HitAcknowledgement.Miss;

            if (_hitCount <= Ship.MaxHitCountPerCell)
                return HitAcknowledgement.Destroyed;

            _hitCount++;
            return HitAcknowledgement.Hit;
        }

        public IShip Ship { get; set; }
    }
}
