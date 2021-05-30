using System;
using System.Collections.Generic;
using WebApplication1.Domain.Moradores;
using WebApplication1.Hypermedia.Abstract;

namespace WebApplication1.Hypermedia.Utils
{
    public class PagedSearchVo<T> where T : ISupportsHyperMedia
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public string SortFields { get; set; }
        public string SortDirections { get; set; }
        
        public Dictionary<string, Object> Filters { get; set; }
        
        public List<T> List { get; set; }
        
        public PagedSearchVo()
        {
        }

        public PagedSearchVo(int currentPage, 
            int pageSize, 
            string sortFields, 
            string sortDirections)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
        }

        public PagedSearchVo(int currentPage, 
            int pageSize, 
            string sortFields, 
            string sortDirections, 
            Dictionary<string, object> filters)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
            SortFields = sortFields;
            SortDirections = sortDirections;
            Filters = filters;
        }

        public PagedSearchVo(int currentPage, 
            string sortFields, 
            string sortDirections) 
            : this(currentPage, 10, sortFields, sortDirections)
        {
        }

        public int GetCurrentPage()
        {
            return CurrentPage == 0 ? 2 : CurrentPage;
        }

        public int GetPageSize()
        {
            return PageSize == 0 ? 10 : PageSize;
        }
    }
}