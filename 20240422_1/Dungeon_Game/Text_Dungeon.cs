using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Game
{
    class Text_Dungeon
    {
        static void Main(string[] args)
        {
            Status status = new Status();
            Inventory inventory = new Inventory();
            Shop shop = new Shop();

            int turn;
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            turn = int.Parse(Console.ReadLine());

            switch (turn)
            {
                case 1:
                    status.Show_Status();
                    break;
                case 2:
                    inventory.Show_Inventory();
                    break;
                case 3:
                    shop.Show_Shop();
                    break;
            }

        }
    }

    class Status
    {
        public Status()
        {

        }

        public void Show_Status()
        {

        }
    }


    class Inventory
    {
        public Inventory()
        {

        }

        public void Show_Inventory()
        {

        }
    }


    class Shop
    {
        public Shop()
        {

        }

        public void Show_Shop()
        {

        }
    }






}
