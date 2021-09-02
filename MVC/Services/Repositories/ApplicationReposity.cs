using AutoMapper;
using DigicelApps.Models;
using DigicelApps.Models.DTOs;
using DigicelApps.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigicelApps.Services.Repositories
{
    public class ApplicationReposity : IApplication
    {
        private DigicelAppContext _db;
        private readonly IMapper _mapper;
        public ApplicationReposity(DigicelAppContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<bool> Create(ApplicationCreationDto app)
        {
            var application = _mapper.Map<Application>(app);
            try
            {
                _db.Add(application);
              await  _db.SaveChangesAsync();

                return  true;
            }
            catch(Exception ex)
            {
                return false;
            }            
        }

        public async Task<bool> Delete(int id)
        {
            var application =await GetById(id);
            try
            {
                _db.Remove(application);
               await _db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            

        }

        public async Task<List<ApplicationDetailDto>> getAll()
        {
            List<ApplicationDetailDto> application = await (from a in _db.Applications join c in _db.Categories
                                                   on a.Category equals c.Id
                                                   select 
                                                   new ApplicationDetailDto(a.Id,a.Name,a.Description,a.Deparment,c.Name,a.Owner )
                                                   ).ToListAsync();
            return application;
        }

        public async Task<List<ApplicationDetailDto>> getAllByWord(string word)
        {
            List<ApplicationDetailDto> apps =await (from a in _db.Applications join c in _db.Categories on a.Category equals c.Id  where a.Name.Contains(word)
                                           || a.Deparment.Contains(word) || a.Description.Contains(word) select 
                                           new ApplicationDetailDto(a.Id,a.Name,a.Description,a.Description,c.Name,a.Owner)
                                           ).ToListAsync();

            return apps;
        }

        public async Task<List<Application>> GetByCategory(int id)
        {
            var category = await (from c in _db.Categories where c.Id == id select c).FirstOrDefaultAsync();
            var apps = await (from a in _db.Applications where a.Category.Equals(category) select a).ToListAsync();

            return apps;
        }

        public async Task<Application> GetById(int id)
        {
            var app = await (from a in _db.Applications where a.Id == id select a).FirstOrDefaultAsync();

            return app;
        }

        public async Task<Application> GetByName(string name)
        {
            var app = await (from a in _db.Applications where a.Name == name select a).FirstOrDefaultAsync();

            return app;
           
        }

        public async Task<bool> Update(Application app)
        {
            var application =await (from a in _db.Applications where a.Id == app.Id select a).FirstOrDefaultAsync();
            try
            {
                application.Name = app.Name;
                application.Description = app.Description;
                application.Category = app.Category;
                application.Owner = app.Owner;

                return await _db.SaveChangesAsync() > 0 ? true : false;
            }catch(Exception ex)
            {
                return false;
            }                      
        }

    }
}
