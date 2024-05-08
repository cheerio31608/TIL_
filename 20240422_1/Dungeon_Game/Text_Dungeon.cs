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
            List<IItem> shopitem = new List<IItem> { new StartArmor(), new IronArmor(), new SpartaArmor(), new BadSword(), new Axe(), new SpartaSpear(), new HealthRing() };

            Start start = new Start();
            Status status = new Status();
            Inventory inventory = new Inventory(shopitem);
            Shop shop = new Shop(shopitem);
            start.Start_Scene(status, inventory, shop);
            

        }
    }

    public class Start
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

    public class Status
    {
        private int level;
        private string chad;
        private int power;
        private int defence;
        private int health;
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

        public void Get_Power(int pow)
        {
            power += pow;
        }

        public void Get_Defence(int def)
        {
            defence += def;
        }
        public void Get_Health(int hel)
        {
            defence += hel;
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


    public class Inventory
    {
        public List<IItem> items;
        public Inventory(List<IItem> sitems)
        {
            this.items = sitems;
        }

        public void Show_Inventory(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            foreach (var item in items)
            {
                if(item.Buied)
                    Console.WriteLine($"- {item.Name} | {item.Type} {item.Stat} | {item.Read} "); ;
            }
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
            int number = 0;
            int listnum = 1;
            List<int> numlist = new List<int>();
            numlist.Add(0);
            foreach (var item in items)
            {
                if (item.Buied)
                {
                    number++; //int number = 0;
                    Console.WriteLine($"- {number} {item.Name} | {item.Type} {item.Stat} | {item.Read} ");
                    numlist.Add(listnum);
                }
                listnum++;
            }
            Console.WriteLine("");

            Console.WriteLine("0. 나가기");
            Console.WriteLine("아이템 번호. 아이템 장착");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int turn = int.Parse(Console.ReadLine());
            while (turn > number)
            {
                Console.WriteLine("잘못된 입력입니다!!!");
                Console.Write(">>");
                turn = int.Parse(Console.ReadLine());
            }
            while (true)
            {
                int turn1 = numlist[turn];
                switch (turn1)
                {
                    case 0:
                        Show_Inventory(start, status, inventory, shop);
                        break;
                    case 1:
                        items[0].Equip(status);
                        Equip_Item(start, status, inventory, shop);
                        break;
                    case 2:
                        items[1].Equip(status);
                        Equip_Item(start, status, inventory, shop);
                        break;
                    case 3:
                        items[2].Equip(status);
                        Equip_Item(start, status, inventory, shop);
                        break;
                    case 4:
                        items[3].Equip(status);
                        Equip_Item(start, status, inventory, shop);
                        break;
                    case 5:
                        items[4].Equip(status);
                        Equip_Item(start, status, inventory, shop);
                        break;
                    case 6:
                        items[5].Equip(status);
                        Equip_Item(start, status, inventory, shop); ;
                        break;
                    case 7:
                        items[6].Equip(status);
                        Equip_Item(start, status, inventory, shop); ;
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!");
                        Console.Write(">>");
                        turn = int.Parse(Console.ReadLine());
                        break;

                }
            }

        }
    }


    public class Shop
    {
        public List<IItem> items;
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
                Console.WriteLine($"- {item.Name} | {item.Type} {item.Stat} | {item.Read} | {item.PriceGold}");;
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
                else if (turn == "2")
                {
                    Sell_Item(start, status, inventory, shop);
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
                Console.WriteLine($"- {number} {item.Name} | {item.Type} {item.Stat} | {item.Read} | {item.PriceGold}");
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
                        items[0].Buy(status);
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "2":
                        items[1].Buy(status); 
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "3":
                        items[2].Buy(status);
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "4":
                        items[3].Buy(status);
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "5":
                        items[4].Buy(status);
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "6":
                        items[5].Buy(status);
                        Buy_Item(start, status, inventory, shop);
                        break;
                    case "7":
                        items[6].Buy(status);
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

        public void Sell_Item(Start start, Status status, Inventory inventory, Shop shop)
        {
            Console.WriteLine("");
            Console.WriteLine("상점 - 아이템 판매");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine("");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{status.gold} G");
            Console.WriteLine("");
            Console.WriteLine("[아이템 목록]");
            int number = 0;
            int listnum = 1;
            List<int> numlist = new List<int>();
            numlist.Add(0);
            foreach (var item in items)
            {
                if (item.Buied)
                {
                    number++;
                    Console.WriteLine($"- {number} {item.Name} | {item.Type} {item.Stat} | {item.Read} ");
                    numlist.Add(listnum);
                }
                listnum++;
            }
            Console.WriteLine("0. 나가기");
            Console.WriteLine("아이템 번호. 아이템 판매");
            Console.WriteLine("");
            Console.WriteLine("원하시는 행동을 입력해주세요");
            Console.Write(">>");
            int turn = int.Parse(Console.ReadLine());
            while (turn > number)
            {
                Console.WriteLine("잘못된 입력입니다!");
                Console.Write(">>");
                turn = int.Parse(Console.ReadLine());
            }
            while (true)
            {
                int turn1 = numlist[turn];
                switch (turn1)
                {
                    case 0:
                        Show_Shop(start, status, inventory, shop);
                        break;
                    case 1:
                        items[0].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 2:
                        items[1].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 3:
                        items[2].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 4:
                        items[3].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 5:
                        items[4].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 6:
                        items[5].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    case 7:
                        items[6].Sell(status);
                        Sell_Item(start, status, inventory, shop);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다!");
                        Console.Write(">>");
                        turn = int.Parse(Console.ReadLine());
                        break;

                }
            }
        }

        void Able_turn()
        {
            Console.WriteLine("");
            Console.WriteLine("2. 아이템 판매");
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
        int Price { get; } //아이템 가격
        string PriceGold { get; }
        bool Buied { get; }
        bool Equiped { get; }

        void Buy(Status status); //아이템을 구매하는 메서드 
        void Sell(Status status); //아이템을 판매하는 메서드
        void Equip(Status status); //아이템을 장착하는 메서드
    }

    //수련자 갑옷 클래스
    public class StartArmor:IItem
    {
        public string IName = "수련자 갑옷";
        public string Name => IName;
        public string Read => "수련에 도움을 주는 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+5";
        public int Price => 500;
        public string priceG = "500G";
        public string PriceGold => priceG;
        
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;


        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if(status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
                
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }

        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }           
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]수련자 갑옷";
                status.Get_Defence(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "수련자 갑옷";
                status.Get_Defence(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

    //무쇠 갑옷 클래스
    public class IronArmor : IItem
    {
        public string IName = "무쇠 갑옷";
        public string Name => IName;
        public string Read => "무쇠로 만들어져 튼튼한 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+9";
        public int Price => 1000;
        public string priceG = "1000G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;

        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]무쇠 갑옷";
                status.Get_Defence(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "무쇠 갑옷";
                status.Get_Defence(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

    //스파르타의 갑옷 클래스
    public class SpartaArmor : IItem
    {
        public string IName = "스파르타의 갑옷";
        public string Name => IName;
        public string Read => "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.";
        public string Type => "방어력";
        public string Stat => "+15";
        public int Price => 1500;
        public string priceG = "1500G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;
        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]스파르타의 갑옷";
                status.Get_Defence(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "스파르타의 갑옷";
                status.Get_Defence(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

    //낡은 검 클래스
    public class BadSword : IItem
    {
        public string IName = "낡은 검";
        public string Name => IName;
        public string Read => "쉽게 볼 수 있는 낡은 검 입니다. ";
        public string Type => "공격력";
        public string Stat => "+2";
        public int Price => 500;
        public string priceG = "500G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;

        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
            else
            {
                Console.WriteLine("가지고 있는 아이템이 아닙니다!");
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]낡은 검";
                status.Get_Power(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "낡은 검";
                status.Get_Power(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

    //청동 도끼 클래스
    public class Axe : IItem
    {
        public string IName = "청동 도끼";
        public string Name => IName;
        public string Read => "어디선가 사용됐던거 같은 도끼입니다. ";
        public string Type => "공격력";
        public string Stat => "+5";
        public int Price => 1000;
        public string priceG = "1000G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;
        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
            else
            {
                Console.WriteLine("가지고 있는 아이템이 아닙니다!");
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]청동 도끼";
                status.Get_Power(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "청동 도끼";
                status.Get_Power(-int.Parse(Stat));
                isEquiped = false;
            }
        }

    }


    //스파르타의 창 클래스
    public class SpartaSpear : IItem
    {
        public string IName = "스파르타의 창";
        public string Name => IName;
        public string Read => "스파르타의 전사들이 사용했다는 전설의 창입니다.";
        public string Type => "공격력";
        public string Stat => "+7";
        public int Price => 1500;
        public string priceG = "1500G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;
        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]스파르타의 창";
                status.Get_Power(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "스파르타의 창";
                status.Get_Power(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

    //체력의 반지 클래스
    public class HealthRing : IItem
    {
        public string IName = "체력의 반지";
        public string Name => IName;
        public string Read => "반지 1개로는 아쉽지만 10개를 전부 모은다면?";
        public string Type => "체력";
        public string Stat => "+2";
        public int Price => 150;
        public string priceG = "150G";
        public string PriceGold => priceG;
        public bool isBuied = false;
        public bool Buied => isBuied;
        public bool isEquiped = false;
        public bool Equiped => isBuied;
        public void Buy(Status status)
        {
            if (!isBuied)
            {
                if (status.gold < Price)
                {
                    Console.WriteLine("Gold가 부족합니다.");
                }
                else
                {
                    status.gold -= Price;
                    Console.WriteLine("구매를 완료했습니다.");
                    priceG = "구매완료";
                    isBuied = true;
                }
            }
            else
            {
                Console.WriteLine("이미 구매한 아이템입니다.");
            }
        }
        public void Sell(Status status)
        {
            if (isBuied)
            {
                status.gold += (int)(Price * 0.85);
                Console.WriteLine("판매를 완료했습니다. ");
                isBuied = false;
                if (isEquiped) Equip(status);
            }
        }
        public void Equip(Status status)
        {
            if (!isEquiped)
            {
                IName = "[E]체력의 반지";
                status.Get_Health(int.Parse(Stat));
                isEquiped = true;
            }
            else
            {
                IName = "체력의 반지";
                status.Get_Health(-int.Parse(Stat));
                isEquiped = false;
            }
        }
    }

}
