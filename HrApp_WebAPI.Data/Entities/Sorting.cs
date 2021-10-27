using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;

namespace HrApp_WebAPI.Entities
{
    public class Sorting
    {
        public void ApplySort(ref IQueryable<Company> companies, string orderByQueryString)
        {
            if (!companies.Any())
                return;

            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                companies = companies.OrderBy(x => x.CompanyName);
                return;
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(Company).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, 
                                                                StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                    continue;

                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
            }

            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                companies = companies.OrderBy(x => x.CompanyName);
                return;
            }

            companies = companies.OrderBy(orderQuery);
        }

        public void SearchByName(ref IQueryable<Company> companies, string companyName)
        {
            if (!companies.Any() || string.IsNullOrWhiteSpace(companyName))
                return;

            if (string.IsNullOrEmpty(companyName))
                return;

            companies = companies.Where(o => o.CompanyName.ToLowerInvariant().Contains(companyName.Trim().ToLowerInvariant()));
        }
    }
}
