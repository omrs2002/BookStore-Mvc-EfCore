using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Employees;
using AutoMapper;


namespace Acme.BookStore.Web
{
    public class BookStoreWebAutoMapperProfile : Profile
    {
        public BookStoreWebAutoMapperProfile()
        {
            CreateMap<BookDto, CreateUpdateBookDto>();

            CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel, CreateAuthorDto>();

            CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
            CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel, UpdateAuthorDto>();

            CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
            CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
            CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();

            //Employees (Add):
            CreateMap<EmployeeDto, CreateUpdateEmployeeDto>().ReverseMap();
            CreateMap<Pages.Employees.CreateModalModel.CreateEmployeeViewModel, CreateUpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, CreateUpdateEmployeeDto>().ReverseMap();

            //Employees (Edit):
            CreateMap<Pages.Employees.EditModalModel.EditEmployeeViewModel, CreateUpdateEmployeeDto>().ReverseMap();
            CreateMap < EmployeeDto, Pages.Employees.EditModalModel.EditEmployeeViewModel>().ReverseMap();
            CreateMap<Employee, Pages.Employees.EditModalModel.EditEmployeeViewModel>().ReverseMap();



        }
    }
}
