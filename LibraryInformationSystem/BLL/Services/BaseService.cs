using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Repository.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.DAL.Entities;

namespace LibraryInformationSystem.LibraryInformationSystem.BLL.Services
{
    public abstract class BaseService<T> where T : BaseEntity
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<T> _repository;

        protected BaseService(IMapper mapper, IGenericRepository<T> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
    }
}