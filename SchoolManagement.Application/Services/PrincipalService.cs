using AutoMapper;
using SchoolManagement.Application.DTOs.PrincipalDtos;
using SchoolManagement.Application.DTOs.StudentDtos;
using SchoolManagement.Application.DTOs.TeacherDtos;
using SchoolManagement.Application.IServices;
using SchoolManagement.Application.Supports.Paginations;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.IRepositories;

namespace SchoolManagement.Application.Services
{
    public class PrincipalService : IPrincipalService
    {
        private readonly IPrincipalRepository _principalRepository;
        private readonly IMapper _mapper;
        public PrincipalService(IPrincipalRepository principalRepository, IMapper mapper)
        {
            _principalRepository = principalRepository;
            _mapper = mapper;
        }

        public async Task AssignTeacherToPrincipalAsync(int id, AssignTeacherDto teacherAdd)
        {
            var teacher = _mapper.Map<PrincipalTeacher>(teacherAdd);
            await _principalRepository.AssignTeacherToPrincipalAsync(id, teacher);
        }

        // Create the new principal
        public async Task CreatePrincipalAsync(CreatePrincipalDto principalDto)
        {
            var principal = _mapper.Map<Principal>(principalDto);
            await _principalRepository.CreatePrincipalAsync(principal);
        }

        public async Task DeletePrincipalAsync(int id)
        {
            await _principalRepository.DeletePrincipalAsync(id);
        }

        public async Task<GetPrincipalIdDto> GetPrincipalByIdAsync(int id)
        {
            var principal = await _principalRepository.GetPrincipalByIdAsync(id);
            return _mapper.Map<GetPrincipalIdDto>(principal);
        }

        public async Task<PaginationTeacher<TeacherDto>> GetPrincipalByIdTeachersAsync(int id, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            var principals = await _principalRepository.GetPrincipalByIdTeachersAsync(id);

            var totalTeachers = principals.Teachers?.Count()??0;
            var totalPages = (int)Math.Ceiling((decimal)totalTeachers / pageSize);

            var teachers = principals.Teachers?
                .OrderBy(s => s.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            var teacherDtos = _mapper.Map<List<TeacherDto>>(teachers);

            return new PaginationTeacher<TeacherDto>
            {
                TotalTeachers = totalTeachers,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Teachers = teacherDtos
            };
        }

        public async Task<PrincipalNumber> GetPrincipalNumbersAsync()
        {
            var principalNumber = await _principalRepository.GetPrincipalNumbersAsync();

            return new PrincipalNumber
            {
                TotalPrincipals = principalNumber.totalPrincipals,
                ActivePrincipals = principalNumber.activePrincipals,
                NotActivePrincipals = principalNumber.notActivePrincipals
            };
        }

        // Get the all principal
        public async Task<PaginationPrincipal<GetPrincipalDto>> GetPrincipalsAsync(bool isActive, int page, int pageSize)
        {
            if (page < 1)
            {
                throw new ArgumentException("Page must be greater than or equal to 1.");
            }

            if (pageSize < 1)
            {
                throw new ArgumentException("Page size must be greater than or equal to 1.");
            }

            List<Principal> principal;
            if (!isActive)
            {
                principal = await _principalRepository.GetPrincipalsNotActiveAsync(page, pageSize);
            }
            else
            {
                principal = await _principalRepository.GetPrincipalsAsync(page, pageSize);
            }

            var result = await _principalRepository.GetPrincipalNumbersAsync();

            var totalPrincipals = result.totalPrincipals;
            var totalPages = (int)Math.Ceiling((decimal)totalPrincipals / pageSize);

            var principalDto = _mapper.Map<List<GetPrincipalDto>>(principal);

            return new PaginationPrincipal<GetPrincipalDto>
            {
                TotalPrincipals = totalPrincipals,
                TotalPages = totalPages,
                CurrentPage = page,
                PageSize = pageSize,
                Principals = principalDto
            };
        }

        public async Task UpdatePrincipalAccountAsync(int Id, PrincipalAccountDto accountDto)
        {
            var account = _mapper.Map<PrincipalAccount>(accountDto);

            await _principalRepository.UpdatePrincipalAccountAsync(Id, account);
        }

        public async Task UpdatePrincipalAsync(int Id, UpdatePrincipalDto principalDto)
        {
            var principal = _mapper.Map<Principal>(principalDto);

            await _principalRepository.UpdatePrincipalAsync(Id, principal);
        }
    }
}
