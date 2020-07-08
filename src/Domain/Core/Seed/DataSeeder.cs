using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Core.Context;
using Core.Entities;

namespace Core.Seed
{
    public class DataSeeder
    {
        private readonly ShortenerContext _shortenerContext;

        public DataSeeder(ShortenerContext shortenerContext)
        {
            _shortenerContext = shortenerContext;
        }

        public async Task PopulateData(int amount)
        {
            if (_shortenerContext.Shortcuts.Count() >= amount)
            {
                throw new Exception("You have already populated data. Comment PopulateData method.");
            }
            
            var redirectFaker = new Faker<Redirect>()
                .RuleFor(a => a.Url, f => f.Internet.Url());

            var redirectExtendedFaker = new Faker<RedirectExtended>()
                .RuleFor(a => a.Url, f => f.Internet.Url());
            
            var shortcutFakerOne = new Faker<Shortcut>()
                .RuleFor(a => a.Alias, f => f.Random.AlphaNumeric(new Random().Next(5,30)))
                .RuleFor(a => a.TimesRedirect, f => f.Random.Long(min:0, max: 999999999));
            
            
            for (var i = 0; i < amount; i++)
            {
                if (i % 2 == 0)
                {
                    Redirect redirect = redirectFaker.Generate();
                    Shortcut shortcut = shortcutFakerOne.Generate();
                  
                    redirect.Shortcut = shortcut;
                    shortcut.Redirect = redirect;
                    
                    await _shortenerContext.AddAsync(redirect);
                    await _shortenerContext.AddAsync(shortcut);
                }
                else
                {
                    RedirectExtended redirectExtended = redirectExtendedFaker.Generate();
                    Shortcut shortcut = shortcutFakerOne.Generate();
                  
                    redirectExtended.Shortcut = shortcut;
                    shortcut.RedirectExtended = redirectExtended;
                    
                    await _shortenerContext.AddAsync(redirectExtended);
                    await _shortenerContext.AddAsync(shortcut);
                }
            }

            await _shortenerContext.SaveChangesAsync();
        } 
    }
}