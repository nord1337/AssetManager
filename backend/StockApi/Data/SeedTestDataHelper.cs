using StockApi.Data.Entities;
using StockApi.Data.Models;

namespace StockApi.Data
{
    public class SeedTestDataHelper
    {
        public static Guid FirstUserGuid = new Guid("0DF883DE-AEFB-4802-B4DF-2B75480290EB");

        public static void SeedAsync(TestDbContext context)
        {
            if (context.TestEntities.Any() is false)
            {
                var testData = Enumerable.Range(1, 100).Select(x => new TestEntity
                {
                    Id = x,
                    Name = $"Test{x}"
                });

                context.TestEntities.AddRange(testData);
            }

            if (context.Users.Any() is false)
            {
                var user = new User { Id = 1, Name = "Kek Kekovich", UserApiKey = FirstUserGuid };
                context.Users.Add(user);
                context.SaveChanges();
            }

            if (context.InvestPortfolios.Any() is false)
            {
                var userId = context.Users.Where(x => x.UserApiKey == FirstUserGuid).FirstOrDefault().Id;
                var portfolios = new List<InvestPortfolio>()
                {
                    new InvestPortfolio
                    {
                        UserId = userId,
                        Name = "Еда и Пивко",
                        About= "Портфель создан из акций и облигаций компаний, производящих съедобную продукцию.",
                        Assets = new[]
                        {
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РусАгро",
                                Ticker= "AGRO",
                                BoughtPrice = 500,
                                CurrentPrice = 1200,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://bondostock.ru/img/ticker-icon/US7496552057x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РусАгро",
                                Ticker= "AGRO",
                                BoughtPrice = 500,
                                CurrentPrice = 1200,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://bondostock.ru/img/ticker-icon/US7496552057x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РусАгро",
                                Ticker= "AGRO",
                                BoughtPrice = 500,
                                CurrentPrice = 1200,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://bondostock.ru/img/ticker-icon/US7496552057x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "X5 RetailGroup ГДР",
                                Ticker= "FIVE",
                                BoughtPrice = 1000,
                                CurrentPrice = 2000,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://companieslogo.com/img/orig/FIVE.ME-fb157f5c.png?t=1654569411"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "X5 RetailGroup ГДР",
                                Ticker= "FIVE",
                                BoughtPrice = 1300,
                                CurrentPrice = 2000,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://companieslogo.com/img/orig/FIVE.ME-fb157f5c.png?t=1654569411"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Магнит",
                                Ticker= "MGNT",
                                BoughtPrice = 7132,
                                CurrentPrice = 8057,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JKQU8x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Магнит",
                                Ticker= "MGNT",
                                BoughtPrice = 8043,
                                CurrentPrice = 8057,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JKQU8x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Магнит",
                                Ticker= "MGNT",
                                BoughtPrice = 7150,
                                CurrentPrice = 8057,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JKQU8x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Магнит",
                                Ticker= "MGNT",
                                BoughtPrice = 7150,
                                CurrentPrice = 8057,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JKQU8x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Абрау-Дюрсо ",
                                Ticker= "ABRD",
                                BoughtPrice = 315,
                                CurrentPrice = 286,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU000A0JS5T7x640.png"
                            }
                        }
                    },
                    new InvestPortfolio
                    {
                        UserId = userId,
                        Name = "Нефть и прочие ресурсы",
                        About= "Портфель создан из акций и облигаций ресурсодобывающих компаний.",
                        Assets = new[]
                        {
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ЛУКОЙЛ",
                                Ticker= "LKOH",
                                BoughtPrice = 3000,
                                CurrentPrice= 5000,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/257/210/png-transparent-lukoil-petroleum-natural-gas-exxonmobil-company-lukoil-text-logo-sign.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ЛУКОЙЛ",
                                Ticker= "LKOH",
                                BoughtPrice = 3000,
                                CurrentPrice= 5000,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/257/210/png-transparent-lukoil-petroleum-natural-gas-exxonmobil-company-lukoil-text-logo-sign.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ЛУКОЙЛ",
                                Ticker= "LKOH",
                                BoughtPrice = 3100,
                                CurrentPrice= 5000,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/257/210/png-transparent-lukoil-petroleum-natural-gas-exxonmobil-company-lukoil-text-logo-sign.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РосНефть",
                                Ticker= "ROSN",
                                BoughtPrice = 500,
                                CurrentPrice= 450,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/323/997/png-transparent-rosneft-hd-logo-thumbnail.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РосНефть",
                                Ticker= "ROSN",
                                BoughtPrice = 510,
                                CurrentPrice= 450,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/323/997/png-transparent-rosneft-hd-logo-thumbnail.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "РосНефть",
                                Ticker= "ROSN",
                                BoughtPrice = 520,
                                CurrentPrice= 450,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://w7.pngwing.com/pngs/323/997/png-transparent-rosneft-hd-logo-thumbnail.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Татнефть",
                                Ticker= "TATN",
                                BoughtPrice = 650,
                                CurrentPrice= 732,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0006944147x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Татнефть",
                                Ticker= "TATN",
                                BoughtPrice = 650,
                                CurrentPrice= 732,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0006944147x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Татнефть",
                                Ticker= "TATN",
                                BoughtPrice = 650,
                                CurrentPrice= 732,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0006944147x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Татнефть",
                                Ticker= "TATN",
                                BoughtPrice = 650,
                                CurrentPrice= 732,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0006944147x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Татнефть",
                                Ticker= "TATN",
                                BoughtPrice = 650,
                                CurrentPrice= 732,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0006944147x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Газпром",
                                Ticker= "GAZP",
                                BoughtPrice = 320,
                                CurrentPrice= 133,
                                Type = AssetTypeEnum.Share,
                                LogoImagePath = "https://invest-brands.cdn-tinkoff.ru/RU0007661625x640.png"
                            },
                        }
                    },
                    new InvestPortfolio
                    {
                        UserId = userId,
                        Name = "Валюта и облигации",
                        About= "Портфель создан из валют и облигаций.",
                        Assets = new[]
                        {
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ОФЗ 228",
                                Ticker= "LKOH",
                                BoughtPrice = 991,
                                CurrentPrice= 996,
                                Type = AssetTypeEnum.Bond,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ОФЗ 1337",
                                Ticker= "LKOH",
                                BoughtPrice = 992,
                                CurrentPrice= 990,
                                Type = AssetTypeEnum.Bond,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ОФЗ 1337",
                                Ticker= "LKOH",
                                BoughtPrice = 992,
                                CurrentPrice= 990,
                                Type = AssetTypeEnum.Bond,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "ОФЗ 1337",
                                Ticker= "LKOH",
                                BoughtPrice = 992,
                                CurrentPrice= 990,
                                Type = AssetTypeEnum.Bond,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "LKOH",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Доллар США $",
                                Ticker= "$",
                                BoughtPrice = 77,
                                CurrentPrice= 99,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180712/zh/kisspng-dollar-sign-united-states-dollar-computer-icons-dollar-signs-5b477c769a0192.4669166315314115746308.jpg"
                            },


                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Евро",
                                Ticker= "Euro",
                                BoughtPrice = 80,
                                CurrentPrice= 101,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180629/wry/kisspng-computer-icons-euro-sign-euro-icon-5b364c27523997.0428592915302850953368.jpg"
                            },
                             new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Евро",
                                Ticker= "Euro",
                                BoughtPrice = 80,
                                CurrentPrice= 101,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180629/wry/kisspng-computer-icons-euro-sign-euro-icon-5b364c27523997.0428592915302850953368.jpg"
                            },
                              new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Евро",
                                Ticker= "Euro",
                                BoughtPrice = 80,
                                CurrentPrice= 101,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180629/wry/kisspng-computer-icons-euro-sign-euro-icon-5b364c27523997.0428592915302850953368.jpg"
                            },
                               new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Евро",
                                Ticker= "Euro",
                                BoughtPrice = 80,
                                CurrentPrice= 101,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180629/wry/kisspng-computer-icons-euro-sign-euro-icon-5b364c27523997.0428592915302850953368.jpg"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Евро",
                                Ticker= "Euro",
                                BoughtPrice = 80,
                                CurrentPrice= 101,
                                Type = AssetTypeEnum.Currency,
                                LogoImagePath = "https://banner2.cleanpng.com/20180629/wry/kisspng-computer-icons-euro-sign-euro-icon-5b364c27523997.0428592915302850953368.jpg"
                            },
                        }
                    },
                    new InvestPortfolio
                    {
                        UserId = userId,
                        Name = "Прочие товары",
                        About= "Портфель из всяких товаров, имеющих ценность",
                        Assets = new[]
                        {
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Монета времен царя Николая II",
                                BoughtPrice = 5000,
                                CurrentPrice = 5100,
                                Type = AssetTypeEnum.Other,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Монета времен царя Николая II",
                                BoughtPrice = 5000,
                                CurrentPrice = 5100,
                                Type = AssetTypeEnum.Other,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Бабушкин сервиз",
                                Ticker= "AGRO",
                                BoughtPrice = 1,
                                CurrentPrice = 2,
                                Type = AssetTypeEnum.Other,
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Виски Ирландский Bushmills",
                                BoughtPrice = 4000,
                                CurrentPrice = 4800,
                                Type = AssetTypeEnum.Other,
                                LogoImagePath = "https://companieslogo.com/img/orig/FIVE.ME-fb157f5c.png?t=1654569411"
                            },
                            new Asset
                            {
                                BuyDate = DateTime.Now,
                                Name = "Набор LEGO Harry Potter",
                                BoughtPrice = 3000,
                                CurrentPrice = 7000,
                                Type = AssetTypeEnum.Other,
                            }
                        }
                    },
                };

                context.InvestPortfolios.AddRange(portfolios);

            }

            context.SaveChanges();
        }
    }
}
