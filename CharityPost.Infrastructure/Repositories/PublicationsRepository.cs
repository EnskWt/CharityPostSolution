using CharityPost.Core.DataTransferObjects.PublicationObjects;
using CharityPost.Core.Enums;
using CharityPost.Infrastructure.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using CharityPost.Core.Domain.Entities.PublicationEntities;
using CharityPost.Core.Domain.RepositoriesContracts;

namespace CharityPost.Infrastructure.Repositories
{
    public class PublicationsRepository : IPublicationsRepository
    {
        private readonly ApplicationDbContext _db;

        public PublicationsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddPublication(Publication publication)
        {
            await _db.AddAsync(publication);
            await _db.SaveChangesAsync();

            return publication.Id;
        }

        public async Task<bool> DeletePublication(Guid publicationId)
        {
            var publication = await _db.Publications.FirstOrDefaultAsync(p => p.Id == publicationId);

            if (publication == null)
            {
                return false;
            }

            _db.Remove(publication);
            await _db.SaveChangesAsync();

            return true;
        }

        public async Task<List<Publication>> GetAllPublications(string sort, Expression<Func<Publication, bool>> filter, int pageNumber, int pageSize)
        {
            var publications = await _db.Publications
                .Where(filter)
                .OrderBy(sort)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return publications;
        }

        public async Task<Publication?> GetPublicationById(Guid publicationId)
        {
            var publication = await _db.Publications
                .Include(p => p.Author)
                .FirstOrDefaultAsync(p => p.Id == publicationId);
            return publication;
        }

        public async Task<Guid> UpdatePublication(Publication publication)
        {
            var matchingPublication = await _db.Publications.FirstOrDefaultAsync(p => p.Id == publication.Id);
            if (matchingPublication == null)
            {
                return publication.Id;
            }

            matchingPublication.Title = publication.Title;
            matchingPublication.Description = publication.Description;
            matchingPublication.PublicationCategory = publication.PublicationCategory;

            await _db.SaveChangesAsync();

            return publication.Id;
        }
    }
}
