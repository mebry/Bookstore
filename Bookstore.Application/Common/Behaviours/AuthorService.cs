using Bookstore.Application.Common.Exceptions;
using Bookstore.Application.Common.Interfaces.Repositories;
using Bookstore.Application.Common.Interfaces.Services;
using Bookstore.Application.Common.Models;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Application.Common.Behaviours
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorReposotiry _authorReposotiry;

        public AuthorService(IAuthorReposotiry authorReposotiry)
        {
            _authorReposotiry = authorReposotiry;
        }

        public async Task<BaseResponse<AuthorDto>> CreateAsync(AuthorDto model)
        {
            var response = new BaseResponse<AuthorDto>();

            try
            {
                if (model is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var author = await _authorReposotiry.CreateAsync(model);

                response.Data = author;
                response.Description = "The author was created";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<bool>> DeleteAsync(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                if (id < 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                await _authorReposotiry.DeleteAsync(id);

                response.Data = true;
                response.Description = "The author was removed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<IEnumerable<AuthorDto>>> GetAllAsync()
        {
            var response = new BaseResponse<IEnumerable<AuthorDto>>();
            try
            {
                var authors = await _authorReposotiry.GetAllAsync();

                response.Data = authors;
                response.Description = "The author was received successfully";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<AuthorDto>> GetByIdAsync(int id)
        {
            var response = new BaseResponse<AuthorDto>();
            try
            {
                if (id < 0)
                {
                    response.Data = null;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var entity = await _authorReposotiry.GetByIdAsync(id);

                response.Data = entity;
                response.Description = "The author was received";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<IEnumerable<AuthorDto>>> GetSoftDeletedAuthorsAsync()
        {
            var response = new BaseResponse<IEnumerable<AuthorDto>>();
            try
            {
                var authors = await _authorReposotiry.GetSoftDeletedAuthorsAsync();

                response.Data = authors;
                response.Description = "The soft removed authors have been received";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<IEnumerable<AuthorDto>>> SearchByLastNameAsync(string authorName)
        {
            var response = new BaseResponse<IEnumerable<AuthorDto>>();
            try
            {
                if (string.IsNullOrWhiteSpace(authorName))
                {
                    response.Data = null;
                    response.Description = "The name can't be null or empty";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var authors = await _authorReposotiry.SearchByLastNameAsync(authorName);

                response.Data = authors;
                response.Description = "The author was received successfully";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<bool>> SetSoftDeleteAsync(int id)
        {
            var response = new BaseResponse<bool>();

            try
            {
                if (id < 0)
                {
                    response.Data = false;
                    response.Description = "This is an incorrect id format. Must be greater than 0";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                bool softStatus = await _authorReposotiry.SetSoftDeleteAsync(id);

                response.Data = softStatus;
                response.Description = "Soft deleted property was changed";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (NotFoundException ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = false;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }

        public async Task<BaseResponse<AuthorDto>> UpdateAsync(AuthorDto model)
        {
            var response = new BaseResponse<AuthorDto>();
            try
            {
                if (model is null)
                {
                    response.Data = null;
                    response.Description = "Model can't be null";
                    response.StatusCode = StatusCode.BadRequest;

                    return response;
                }

                var entity = await _authorReposotiry.UpdateAsync(model);

                response.Data = entity;
                response.Description = "The author was updated";
                response.StatusCode = StatusCode.OK;

                return response;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.NotFound;

                return response;
            }
            catch (Exception ex)
            {
                response.Data = null;
                response.Description = ex.Message;
                response.StatusCode = StatusCode.InternalServerError;

                return response;
            }
        }
    }
}
