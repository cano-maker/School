using School.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Web.Data
{
    public class SeedDb
    {
        private readonly ApplicationDbContext _context;
        public SeedDb(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
        }
        private async Task CheckCountriesAsync()
        {
            if (!_context.Cities.Any())
            {
                _context.Cities.Add(new City
                {
                    Name = "Medellín",
                    Neighborhoods = new List<Neighborhood> {
            new Neighborhood {
              Name = "Santa Rita",
              Students = new List < Student > {
                new Student {
                  Name = "Juan",
                  LastName = "Lopez",
                  Document = 697425,
                  NumberPhone = "3213454567",
                  Email = "juan@gmail.com",
                  Level = 1,
                  Age = "23"
                },
                new Student {
                  Name = "Andres",
                  LastName = "Garcia",
                  Document = 6974525,
                  NumberPhone = "3213454667",
                  Email = "andres@gmail.com",
                  Level = 2,
                  Age = "43"
                },
                new Student {
                  Name = "Isabel",
                  LastName = "Vallejo",
                  Document = 69744525,
                  NumberPhone = "3213457867",
                  Email = "isabel@gmail.com",
                  Level = 5,
                  Age = "24"
                }
              }
            },
            new Neighborhood

            {
              Name = "Villa Loma",
              Students = new List < Student >

              {
                new Student {
                  Name = "Cristian",
                  LastName = "Castaño",
                  Document = 69745425,
                  NumberPhone = "3453454567",
                  Email = "cistian@gmail.com",
                  Level = 6,
                  Age = "22"
                }

              }
            },
            new Neighborhood

            {
              Name = "Valle del Cauca",
              Students = new List < Student >

              {
                new Student {
                  Name = "Milena",
                  LastName = "Cano",
                  Document = 69742545,
                  NumberPhone = "321354567",
                  Email = "mileno@gmail.com",
                  Level = 4,
                  Age = "13"
                },
                new Student {
                  Name = "Jennifer",
                  LastName = "Aristizabal",
                  Document = 69742565,
                  NumberPhone = "3213674567",
                  Email = "jenny@gmail.com",
                  Level = 3,
                  Age = "21"
                },
                new Student {
                  Name = "Pablo",
                  LastName = "Emilia",
                  Document = 6974425,
                  NumberPhone = "3463454567",
                  Email = "pablo@gmail.com",
                  Level = 1,
                  Age = "20"
                }

              }

            }

          }
                });
                _context.Cities.Add(new City

                {
                    Name = "Bogota",
                    Neighborhoods = new List<Neighborhood>

          {
            new Neighborhood

            {
              Name = "Bosa",
              Students = new List < Student >

              {
                new Student {
                  Name = "Ramiro",
                  LastName = "Lopez",
                  Document = 697425,
                  NumberPhone = "3213454567",
                  Email = "ramiro@gmail.com",
                  Level = 1,
                  Age = "23"
                },
                new Student {
                  Name = "Frank",
                  LastName = "Castro",
                  Document = 69744425,
                  NumberPhone = "3223454567",
                  Email = "Frank@gmail.com",
                  Level = 1,
                  Age = "20"
                },
                new Student {
                  Name = "David",
                  LastName = "Valencia",
                  Document = 69742445,
                  NumberPhone = "321348767",
                  Email = "david@gmail.com",
                  Level = 2,
                  Age = "23"
                }

              }
            },
            new Neighborhood

            {
              Name = "Chapinero",
              Students = new List < Student >

              {
                new Student {
                  Name = "Carlos",
                  LastName = "Lopez",
                  Document = 697425,
                  NumberPhone = "321345447",
                  Email = "carlos@gmail.com",
                  Level = 1,
                  Age = "23"
                },
                new Student {
                  Name = "Hugo",
                  LastName = "Lopez",
                  Document = 697425,
                  NumberPhone = "33213454567",
                  Email = "hugo@gmail.com",
                  Level = 1,
                  Age = "23"
                }

              }

            }

          }
                });
                await _context.SaveChangesAsync();

            }

        }
    }
}