﻿using MediatR;
using NetCore.Infrastructure.Database.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCore.Infrastructure.Database.Handlers
{
    public class UpdateGenderHandler : IRequestHandler<UpdateGenderRequest, UpdateGenderResponse>
    {
        private readonly DatabaseContext _databaseContext;

        public UpdateGenderHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<UpdateGenderResponse> Handle(UpdateGenderRequest request, CancellationToken cancellationToken)
        {
            var existingPerson = GetExistingPerson(request);
            if (existingPerson == null)
            {
                //todo: handle exception
                return await Task.FromResult(new UpdateGenderResponse(false));
            }

            MapPerson(request, existingPerson);
            await _databaseContext.Set<Person>().AddAsync(existingPerson, cancellationToken);
            await _databaseContext.SaveChangesAsync(cancellationToken);

            return await Task.FromResult(new UpdateGenderResponse(true));
        }

        private Person GetExistingPerson(UpdateGenderRequest request)
        {
            return _databaseContext.Set<Person>().SingleOrDefault(x => x.Id == request.Id);
        }

        private void MapPerson(UpdateGenderRequest request, Person existingPerson)
        {
            //existingPerson.BirthYear = request.BirthYear.Value;
            //existingPerson.DeathYear = request.DeathYear.Value;
            //existingPerson.NameConst = request.NameConst;
            //existingPerson.PrimaryName = request.PrimaryName;

            //if (request.BirthYear != null && request.BirthYear != existingPerson.BirthYear)
            //{
            //    existingPerson.BirthYear = request.BirthYear.Value;
            //}

            //if (request.DeathYear != null && request.DeathYear != existingPerson.DeathYear)
            //{
            //    existingPerson.DeathYear = request.DeathYear.Value;
            //}

            //if (request.NameConst != null && request.NameConst != existingPerson.NameConst)
            //{
            //    existingPerson.NameConst = request.NameConst;
            //}

            //if (request.PrimaryName != null && request.PrimaryName != existingPerson.PrimaryName)
            //{
            //    existingPerson.PrimaryName = request.PrimaryName;
            //}
        }
    }
}
