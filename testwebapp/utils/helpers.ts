import { useAuthStore } from '~/store/auth.store'
import { isProxy, computed } from 'vue';

export enum HttpQueryType
{
  get = 'GET',
  post = 'POST',
  put = 'PUT',
  delete = 'DELETE',
}

export enum DateType
{
  date,
  month,
}

export interface IHttpQuery
{
  method: string,
  headers: any,
  body?: any
}

export interface ILengthRule
{
  min?: number,
  max?: number,
}

export interface FloatValidatorOptions {
  value: string | number | null | undefined;
  rule?: { min?: number | undefined; max?: number | undefined };
  short?: boolean;
  text?: string;
  suffix?: string;
}

export function convertDateStringToISOString(date: string, type: DateType) {
  if (!date) return ''

  let day = ''
  let month = ''
  let year = ''

  const s = date.split('.')

  if (type === DateType.month) {
    // MM.yyyy
    day = '01'
    month = s[0]
    year = s[1]
  } else {
    // dd.MM.yyyy
    day = s[0]
    month = s[1]
    year = s[2]
  }

  const result = `${year}-${month}-${day}T00:00:00`
  // const result = `${year}-${month}-${day}`
  const test = new Date(result)

  if (isValidDate(test)) {
    return result
  }
  return ''
}

export function isValidDate(d?: Date) {
  return d instanceof Date && d.getFullYear() >= 1000
}

export interface IListRequestFront {
    pagination?: IPagination,
    search?: string,
    sort?: { prop: string, isDesc: boolean }[],
    filter?: any,
    dateTime?: any,
    isActual?: boolean
}

export interface IListRequestBack {
    page: number,
    size: number,
    search: string,
    dateTime: DateType,
    isActual: boolean,
    sort: ISortItem[],
    filter:IFilterItem[],
}

export interface IPagination {
    page: number,
    itemsPerPage: number,
    // sortBy?: string,
    // sortDesc?: boolean,
}

export interface ISortItem {
    prop: string,
    isDesc: boolean,
}

export interface IFilterItem {
    prop: string,
    value: any,
}

interface IHelpers {
  getListRequest: (item: IListRequestFront) => IListRequestBack,
  BuildQuery: (queryType: HttpQueryType, postBody?: any) => IHttpQuery,
}

export default function helpers() : IHelpers
{
  const getListRequest = function(item: IListRequestFront): IListRequestBack {
    if(isProxy(item.pagination)) {
      item.pagination = { page: 1, itemsPerPage: -1 }
    }
    if (!item.sort) {
        item.sort = []
    }
    if (!item.search) {
        item.search = ''
    }
    if (!item.isActual) {
        item.isActual = false
    }
    if(!item.filter) {
      item.filter = []
    }
  
    const result = {
      page: item.pagination ? item.pagination.page : 1,
      size: item.pagination ? item.pagination.itemsPerPage : -1,
      search: item.search.trim(),
      sort: item.sort,
      filter: item.filter,
      dateTime: item.dateTime,
      isActual: item.isActual,
    }
  
    // if (item.pagination.sortBy != null && item.pagination.sortDesc != null) {
    //     result.sort.push({ prop: item, isDesc: item.pagination.sortDesc[index] });
    // }
  
    return result;
  }

  const BuildQuery = function(queryType: HttpQueryType, postBody?: any): IHttpQuery
  {
    //const authtoken = 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIiwianRpIjoiMiIsInR5cCI6IkFjY2VzcyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6ImFkbWluaXN0cmF0b3IiLCJleHAiOjE3MTkwNTc3MjgsImlzcyI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAzNyIsImF1ZCI6Imh0dHA6Ly9sb2NhbGhvc3Q6NTAzNyJ9.3P0mKxL8FUX9s9G_jfO0DtCjVEmCkNG5KTY0FO_book'
    const authStore = useAuthStore()
    if(queryType == HttpQueryType.post || queryType == HttpQueryType.put) {
      return {
        method: queryType.toString(),
        headers: 
        {
          'Content-Type': 'application/json', 
          'Authorization': `Bearer ${computed(() => authStore.accessToken).value}`,
          //'Authorization': `Bearer ${authtoken}`,
          
        },
        body: JSON.stringify(postBody)
      }
    }
    else {
      return {
        method: queryType.toString(),
        headers: 
        {
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${authStore.accessToken}`,
        },
      }
    }
  }

  return {
    getListRequest,
    BuildQuery,
  }
}