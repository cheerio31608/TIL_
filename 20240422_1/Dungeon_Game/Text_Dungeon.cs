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
            List<IItem> shopitem = new List<IItem> { new StartArmor(), new IronArmor(), new SpartaArmor(), new BadSword(), new Axe(), new SpartaSpear() };

            Start start = new Start();
            Status status = new Status();
            Inventory inventory = new Inventory();
            Shop shop = new Shop(shopitem);
            start.Start_Scene(status, inventory, shop);
            

        }
    }

    class Start
    {
        public Start()
        {

        }

        public void Start_Scene(Status status, Inventory inventory, Shop shop)
        {
            int turn;
            Console.WriteLine("");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            able_turn();
            turn = int.Parse(Console.ReadLine());

            while(true)
            {
                switch (turn)
                {
                    case 1:
                        status.Show_Status(this, status, inventory, shop);
                        break;
                    case 2:
                        inventory.Show_Inventory(this, status, inventory, shop);
                        break;
                    case 3:
                        shop.Show_Shop(this, status, inventory, shop);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        able_turn();
                        turn = int.Parse(Console.ReadLine());
                        break;
                }
            }
        }
        void able_turn()
        {
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
        }
    }

    class Status
    {
        int level;
        string chad;
        int power;
        int defence;
        int health;
        public int gold;
        public Status()
        {
            level = 01;
            chad = "전사";
            power = 10;
            defence = 5;
            health = 100;
            gold = 1500;
        }

        public void Show_Status(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine($"Lv.{level}");
            Console.WriteLine($"chad ({chad})");
            Console.WriteLine($"공격력 : {power}");
            Console.WriteLine($"방어력 : {defence}");
            Console.WriteLine($"체력 : {health}");
            Console.WriteLine($"Gold : {gold} G");
            Able_turn();
            string turn = Console.ReadLine();
            while(true)
            {
                if (turn == "0")
                {
                    start.Start_Scene(status, inventory, shop);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Able_turn();
                    turn = Console.ReadLine();
                }
            }
        }       

        void Able_turn()
        {
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }
    }


    class Inventory
    {
        public Inventory()
        {

        }

        public void Show_Inventory(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Able_turn();
            string turn = Console.ReadLine();
            while (true)
            {
                if (turn == "0")
                {
                    start.Start_Scene(status, inventory, shop);
                    break;
                }
                else if(turn == "1")
                {
                    Equip_Item(start, status, inventory, shop);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Able_turn();
                    turn = Console.ReadLine();
                }
            }
        }

        void Able_turn()
        {
            Console.WriteLine("");
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }

        void Equip_Item(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("");
            Able_turn();
            string turn = Console.ReadLine();
            while (true)
            {
                if (turn == "0")
                {
                    this.Show_Inventory(start, status, inventory, shop);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Able_turn();
                    turn = Console.ReadLine();
                }
            }

        }
    }


    class Shop
    {
        private List<IItem> items;
        public Shop(List<IItem> sitems)
        {
            this.items = sitems;
        }

        public void Show_Shop(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("상점");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{status.gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            foreach (var item in items)
            {
                Console.WriteLine($"- {item.Name} | {item.Type} {item.Stat} | {item.Read} | {item.priceGold}");;
            }
            Console.WriteLine("");
            Able_turn();
            string turn = Console.ReadLine();
            while (true)
            {
                if (turn == "0")
                {
                    start.Start_Scene(status, inventory, shop);
                    break;
                }
                else if (turn == "1")
                {
                    Buy_Item(start, status, inventory, shop);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다!");
                    Able_turn();
                    turn = Console.ReadLine();
                }
            }
        }

        public void Buy_Item(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("상점 - 아이템 구매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{status.gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            int number = 1;
            foreach (var item in items)
            {
                Console.WriteLine($"- {number} {item.Name} | {item.Type} {item.Stat} | {item.Read} | {item.priceGold}");
                number++;
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            string turn = Console.ReadLine();
            while (true)
            {
                switch (turn)
                {
                    case "0":
                        Show_Shop(start, status, inventory, shop);
                        break;
                    case "1":
                        items[0].Buy();
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "2":
                        items[1].Buy(); 
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "3":
                        items[2].Buy();
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "4":
                        items[3].Buy();
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "5":
                        items[4].Buy();
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "6":
                        items[5].Buy();
                        Buy_Item(start, status, inventory, shop);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!");
                        Console.Write(">>");
                        turn = Console.ReadLine();
                        break;

                }

                
            }
        }

        void Able_turn()
        {
            Console.WriteLine("");
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
        }
    }
    
    //아이템 인터페이스 정의
    public interface IItem
    {
        string Name { get; } //아이템 이름
        string Read { get; } //아이템 설명
        string Type { get; } //아이템 타입
        string Stat { get; } //아이템 스탯
        int price { get; } //아이템 가격
        string priceGold { get; }

        void Buy(); //아이템을 구매하는 메서드 
        void Equip(); //아이템을 장착하는 메서드
    }

    //수련자 갑옷 클래스
    public class StartArmor:IItem
    {
        public string Name => "수련자 갑옷";
        public string Read => "수련에 도움을 주는 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+5";
        public int price => 500;
        public string priceGold => price + "G";
 

        public void Buy()
        {
            Console.WriteLine("1번 아이템 구매");
        }
        public void Equip()
        {

        }
    }

    //무쇠 갑옷 클래스
    public class IronArmor : IItem
    {
        public string Name => "무쇠 갑옷";
        public string Read => "무쇠로 만들어져 튼튼한 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+9";
        public int price => 1000;
        public string priceGold => price + "G";



        public void Buy()
        {
            Console.WriteLine("2번 아이템 구매");

        }
        public void Equip()
        {

        }
    }

    //스파르타의 갑옷 클래스
    public class SpartaArmor : IItem
    {
        public string Name => "스파르타의 갑옷";
        public string Read => "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+15";
        public int price => 1500;
        public string priceGold => price + "G";


        public void Buy()
        {
            Console.WriteLine("3번 아이템 구매");
            
        }
        public void Equip()
        {

        }
    }

    //낡은 검 클래스
    public class BadSword : IItem
    {
        public string Name => "낡은 검";
        public string Read => "쉽게 볼 수 있는 낡은 검 입니다. ";
        public string Type => "공격력";
        public string Stat => "+2";
        public int price => 500;
        public string priceGold => price + "G";



        public void Buy()
        {
            Console.WriteLine("4번 아이템 구매");

        }
        public void Equip()
        {

        }
    }

    //청동 도끼 클래스
    public class Axe : IItem
    {
        public string Name => "청동 도끼";
        public string Read => "어디선가 사용됐던거 같은 도끼입니다. ";
        public string Type => "공격력";
        public string Stat => "+5";
        public int price => 1000;
        public string priceGold => price + "G";


        public void Buy()
        {
            Console.WriteLine("5번 아이템 구매");

        }
        public void Equip()
        {

        }
    }

    //스파르타의 창 클래스
    public class SpartaSpear : IItem
    {
        public string Name => "스파르타의 창";
        public string Read => "스파르타의 전사들이 사용했다는 전설의 창입니다.";
        public string Type => "공격력";
        public string Stat => "+7";
        public int price => 1500;
        public string priceGold => price + "G";


        public void Buy()
        {
            Console.WriteLine("6번 아이템 구매");

        }
        public void Equip()
        {

        }
    }



}
