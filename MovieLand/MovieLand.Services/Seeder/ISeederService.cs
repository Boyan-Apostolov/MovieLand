using System;
using System.Collections.Generic;
using System.Text;

namespace MovieLand.Services.Seeder
{
    public interface ISeederService
    {
        public int SeedMovies(int fromCount, int toCount);
    }
}
