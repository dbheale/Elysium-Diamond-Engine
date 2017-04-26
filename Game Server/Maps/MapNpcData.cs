using System;
using System.Collections.Generic;
using GameServer.Npcs;

namespace GameServer.Maps {
    public class MapNpcData : IMapNpc {
        /// <summary>
        /// ID de npc.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// ID único de npc.
        /// </summary>
        public int UniqueID { get; set; }

        /// <summary>
        /// HP do npc no mapa.
        /// </summary>
        public int HP { get; set; }

        /// <summary>
        /// Quantidade máxima de HP.
        /// </summary>
        public int MaxHP { get; set; }

        /// <summary>
        /// Coordenada X.
        /// </summary>
        public short X { get; set; }

        /// <summary>
        /// Coordenada Y.
        /// </summary>
        public short Y { get; set; }

        /// <summary>
        /// Perímetro de movimento.
        /// </summary>
        public byte Range { get; set; }

        /// <summary>
        /// Direção do movimento.
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Fila de direções dos movimentos.
        /// </summary>
        public Queue<Direction> DirectionQueue = new Queue<Direction>();

        /// <summary>
        /// Tickcount para o movimento do npc
        /// </summary>
        //public int SendTick { get; set; }

        /// <summary>
        /// Posição inicial
        /// </summary>
        private short _x, _y;
      
        /// <summary>
        /// Tickcount de movimento.
        /// </summary>
        private int moveTick;

        /// <summary>
        /// Tempo para executar o movimento.
        /// </summary>
        private int moveTime;

        private Random rnd = new Random();
        
        /// <summary>
        /// Inicia um novo Npc.
        /// </summary>
        public MapNpcData() {

        }

        /// <summary>
        /// Inicia um novo npc.
        /// </summary>
        /// <param name="id">id de npc</param>
        /// <param name="x">coordenada x</param>
        /// <param name="y">coordenada y</param>
        public MapNpcData(int id, int uniqueid, short x, short y, byte range, int time) {
            ID = id;
            UniqueID = uniqueid;
            X = _x = x;
            Y = _y = y;
            Range = range;
            moveTime = time;
        }

        /// <summary>
        /// Obtem o valor do HP do npc a partir da fonte original.
        /// </summary>
        public void CreateHP() {
            HP = MaxHP = NpcManager.FindByID(ID).HP;
        }

        /// <summary>
        /// Computa todo o AI do npc.
        /// </summary>
        public void Compute() {
            GenerateDirection();
        }

        /// <summary>
        /// Move o personagem em uma coordenada.
        /// </summary>
        public void Move() {
            switch (Direction) {
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;             
            }
        }

        /// <summary>
        /// Cria uma direção e quantidade de movimentos para o npc.
        /// </summary>
        private void GenerateDirection() {
            if (Environment.TickCount >= moveTick + moveTime) {

                var _dir = (Direction)rnd.Next((int)Direction.Up, (int)Direction.Right + 1);
                var _move = rnd.Next(1, Range + 1);

                //Se o movimento não é permitido, retorna.
                if (IsInsideRange(_dir, (short)_move) == false) return;

                //Adiciona o movimento na lista para ser enviado ao mapa.
                for (var i = 0; i < _move; i++) DirectionQueue.Enqueue(_dir);

                moveTick = Environment.TickCount;
            }
        }

        /// <summary>
        /// Verifica se o npc pode mover-se dentro da região de alcance.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="coord"></param>
        /// <returns></returns>
        private bool IsInsideRange(Direction direction, short coord) {
            switch (direction) {
                case Direction.Up:
                    if (Y - coord <= _y - Range) return false;
                    break;
                case Direction.Down:
                    if (Y + coord >= Range + _y) return false;
                    break;
                case Direction.Left:
                    if (X - coord <= _x - Range) return false;
                    break;
                case Direction.Right:
                    if (X + coord >= Range + _x) return false;
                    break;
            }

            return true;
        }
    }
}

