using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System;
using Comm2Tender.Logic.Models;

namespace Comm2Tender.Data
{
    public static class Extensions
    {
        public static IQueryable<T> WhereDynamic<T>(this IQueryable<T> source, List<Logic.Models.FilterItem> filters)
        {
            if (source != null && filters?.Any() == true)
            {
                foreach (var filter in filters)
                {
                    source = source.WhereName(filter.Prop, filter.Value);
                }
            }
            return source;
        }

        private static IQueryable<T> WhereName<T>(this IQueryable<T> source, string propertyName, object value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return source;
            }

            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "a");
            Expression body = parameter;
            foreach (var member in propertyName.Split('.'))
            {
                var propertyInfo = type.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new Exception($"Параметр '{propertyName}', поле '{member}'");
                }
                type = propertyInfo.PropertyType;
                body = Expression.PropertyOrField(body, member);
            }

            try
            {
                Type underlyingType = Nullable.GetUnderlyingType(type);
                Type propertyType = underlyingType ?? type;
                if (underlyingType != null && value == null)
                {
                    // Для Nullable типов разрешаем передачу значений null
                    value = null;
                }
                else if (value is JsonElement element)
                {
                    value = element.ValueKind switch
                    {
                        JsonValueKind.String => element.GetString(),
                        JsonValueKind.Number => element.GetInt64(),
                        JsonValueKind.True => true,
                        JsonValueKind.False => false,
                        JsonValueKind.Undefined => null,
                        JsonValueKind.Null => null,
                        _ => throw new Exception($"Значение '{element.GetRawText()}' параметра {propertyName} не удалось привести к типу {type}. ValueKind {element.ValueKind}."),
                    };
                    value = Convert.ChangeType(value, propertyType, CultureInfo.InvariantCulture);
                }
                else
                {
                    //throw new TypeCastException($"Похоже стоит раскомментировать строку ниже...");
                    value = Convert.ChangeType(value, propertyType, CultureInfo.InvariantCulture);
                }

            }
            catch
            {
                var valueString = value == null ? "null" : value.ToString();
                throw new Exception($"Значение '{valueString}' параметра {propertyName} не удалось привести к типу {type}");
            }

            ConstantExpression valueExp = Expression.Constant(value, type);
            Expression equalExpression = Expression.Equal(body, valueExp);
            LambdaExpression lambda = Expression.Lambda(equalExpression, parameter);
            MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), "Where", new Type[] { typeof(T) }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(resultExpression);
        }

        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, List<SortItem> sorts)
        {
            if (source != null && sorts?.Any() == true)
            {
                foreach (var sort in sorts)
                {
                    source = source.OrderByName(sort.Prop, sort.IsDesc, (source.Expression.Type == typeof(IOrderedQueryable<T>)));
                }
            }
            return source;
        }

        private static IQueryable<T> OrderByName<T>(this IQueryable<T> source, string propertyName, bool isDesc, bool isThen)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
            {
                return source;
            }

            Type type = typeof(T);
            ParameterExpression parameter = Expression.Parameter(type, "a");
            Expression body = parameter;

            foreach (var member in propertyName.Split('.'))
            {
                var propertyInfo = type.GetProperty(member, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                if (propertyInfo == null)
                {
                    throw new Exception($"Параметр '{propertyName}', поле '{member}'");
                }
                type = propertyInfo.PropertyType;
                body = Expression.PropertyOrField(body, member);
            }

            string methodName = isThen ? "ThenBy" : "OrderBy";
            if (isDesc)
            {
                methodName += "Descending";
            }

            LambdaExpression lambda = Expression.Lambda(body, parameter);
            MethodCallExpression resultExpression = Expression.Call(typeof(Queryable), methodName, new Type[] { typeof(T), type }, source.Expression, Expression.Quote(lambda));
            return source.Provider.CreateQuery<T>(resultExpression);
        }
    }
}
