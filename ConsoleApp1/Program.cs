using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static RezUserRepository _rezUserRepository;
        static RezRightRepository _rezRightRepository;
        static UserRightRepository _userRightRepository;
        static PlaceRepository _placeRepository;
        static RezervationRepository _rezervationRepository;
        static void Main(string[] args)
        {

            var ctx = new RezContext();
            _rezUserRepository = new RezUserRepository(ctx);
            _rezRightRepository = new RezRightRepository(ctx);
            _userRightRepository = new UserRightRepository(ctx);
            _placeRepository = new PlaceRepository(ctx);
            _rezervationRepository = new RezervationRepository(ctx);


            Console.WriteLine("Hello World!");

            while (true)
            {
                Console.WriteLine(@"user oluşturmak için 1, listeleme için 2  
                                   silmek için 3, yetki oluşturmak iiçin 4 
                                   yetki listelemek için 5 
                                    user a yetki vermek için 6
                                    user görüntülemek için 7,
                                    yer oluşturmak için 8,
                                    yer Listelemek için 9,

                                   giriniz: ");
                int islem = Convert.ToInt32(Console.ReadLine());

                if (islem == 1)
                {
                    CreateUser();
                }
                else if (islem == 2)
                {
                    ListUsers();
                }
                else if (islem == 3)
                {
                    DeleteUser();
                }
                else if (islem == 4)
                {
                    CreateRight();
                }
                else if (islem == 5)
                {
                    ListRight();
                }
                else if (islem == 6)
                {
                    AddRightToUser();
                }
                else if (islem == 7)
                {
                    GetUserById();
                }
                else if (islem == 8)
                {
                    CreatePlace();
                }
                else if (islem == 9)
                {
                    ListPlaces();
                }
                else if (islem == 10)
                {
                    ShowPlace();
                }
                else if (islem == 11)
                {
                    MakeRez();
                }
            }
        }

        private static void MakeRez()
        {
            Console.WriteLine("Place Id giriniz:");
            int placeId = Convert.ToInt32(Console.ReadLine());

            var place = _placeRepository.GetById(placeId);


            Console.WriteLine("Tarih giriniz Gun:AY:yıl");
            var dateProps = Console.ReadLine().Split(":");
            DateTime gun = new DateTime(Convert.ToInt32(dateProps[2]), Convert.ToInt32(dateProps[1]), Convert.ToInt32(dateProps[0]));

            List<Rezervation> rezList = _rezervationRepository.List();

            List<int> avaliableHours = new List<int>();
            for (int i = 0; i < 24; i++)
            {
                DateTime checkDate = new DateTime(gun.Year, gun.Month, gun.Day, i, 0, 0);
                if (!rezList.Any(c => c.Status != (int)RezstatusEnum.CANCELED && c.StartDate == checkDate))
                {
                    avaliableHours.Add(i);
                    Console.WriteLine(checkDate.ToShortTimeString());
                }

            }


            int saat = -1;

            while (true)
            {
                Console.WriteLine("saat giriniz");
                saat = Convert.ToInt32(Console.ReadLine());
                if (!avaliableHours.Contains(saat))
                {
                    Console.WriteLine("Girilen saat dolu");
                    continue;
                }
                break;
            }

            DateTime startDate = new DateTime(gun.Year, gun.Month, gun.Day, saat, 0, 0);
            DateTime endDate = startDate.AddHours(1);

            Rezervation rezervation = new Rezervation()
            {
                UserId = 1,
                Price = place.Price,
                PlaceId = place.Id,
                Status = (int)RezstatusEnum.RESERVED,
                StartDate = startDate,
                EndDate = endDate

            };

            _rezervationRepository.Create(rezervation);

        }

        private static void CreatePlace()
        {
            Console.WriteLine("place name,price,owner giriniz");
            var props = Console.ReadLine().Split(",");
            Place place = new Place()
            {
                Name = props[0],
                Price = Convert.ToDecimal(props[2]),
                Owner = Convert.ToInt32(props[1])
            };
            _placeRepository.Create(place);
        }

        private static void ListPlaces()
        {
            var placeList = _placeRepository.List();

            var users = _rezUserRepository.List();

            foreach (var place in placeList)
            {
                var usr = users.First(c => c.Id == place.Owner);
                Console.WriteLine($"{place.Id}--{place.Name}--{place.Price}--{usr.UserName}");
            }
        }

        private static void ShowPlace()
        {
            Console.WriteLine("Place Id giriniz");
            int placeId = Convert.ToInt32(Console.ReadLine());
            Place place = _placeRepository.GetById(placeId);

            Console.WriteLine("Tarih giriniz Gun:AY:yıl");
            var dateProps = Console.ReadLine().Split(":");
            DateTime gun = new DateTime(Convert.ToInt32(dateProps[2]), Convert.ToInt32(dateProps[1]), Convert.ToInt32(dateProps[0]));

            List<Rezervation> rezList = _rezervationRepository.List();

            for (int i = 0; i < 24; i++)
            {
                DateTime checkDate = new DateTime(gun.Year, gun.Month, gun.Day, i, 0, 0);
                if (!rezList.Any(c => c.Status != (int)RezstatusEnum.CANCELED && c.StartDate == checkDate))
                {
                    Console.WriteLine(checkDate.ToShortTimeString());
                }

            }

        }

        private static void GetUserById()
        {
            Console.WriteLine("User Id giriniz:");
            int id = Convert.ToInt32(Console.ReadLine());
            var usr = _rezUserRepository.GetById(id);

            var usrRights = _userRightRepository.GetRights(usr.Id);

            Console.WriteLine($"{usr.UserName}");
            foreach (var rght in usrRights)
            {
                Console.WriteLine($"{rght.Name}");
            }

        }

        private static void AddRightToUser()
        {
            Console.WriteLine("Ekleme Yapılacak user Id si giriniz");
            int id = Convert.ToInt32(Console.ReadLine());
            var usr = _rezUserRepository.GetById(id);
            Console.WriteLine($"{usr.Id}--{usr.UserName}");
            Console.WriteLine("eklenecek yetki id si giriniz:");
            int rightId = Convert.ToInt32(Console.ReadLine());

            UserRight userRight = new UserRight();
            userRight.RezRightId = rightId;
            userRight.UserId = usr.Id;

            _userRightRepository.Create(userRight);

        }

        private static void ListRight()
        {
            var rezList = _rezRightRepository.List();
            foreach (var right in rezList)
            {
                Console.WriteLine($"{right.Id}--{right.Name}");
            }
        }

        private static void CreateRight()
        {
            Console.WriteLine("Yetki ismi giriniz");
            RezRight rezRight = new RezRight();
            rezRight.Name = Console.ReadLine();
            _rezRightRepository.Create(rezRight);
        }

        private static void DeleteUser()
        {
            Console.WriteLine("silinecek User id giriniz");
            int id = Convert.ToInt32(Console.ReadLine());

            var silinecek = _rezUserRepository.GetById(id);
            Console.WriteLine($"{silinecek.UserName} siliencek Emin misiniz E/H");
            string onay = Console.ReadLine();
            if (onay != "E")
                return;
            _rezUserRepository.Delete(silinecek);
        }

        private static void ListUsers()
        {
            var users = _rezUserRepository.List();
            foreach (var usr in users)
            {
                Console.WriteLine($"{usr.Id} - {usr.UserName} - {usr.Password}");
            }
        }

        static void CreateUser()
        {

            RezUser usr = new RezUser();
            Console.WriteLine("User Name giriniz:");
            usr.UserName = Console.ReadLine();

            Console.WriteLine("User password giriniz:");
            usr.Password = Console.ReadLine();

            _rezUserRepository.Create(usr);
        }
    }
}
