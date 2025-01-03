﻿using CarBook.Domain.Entities;
using CarBookApplication.Features.Mediator.Commands.CommentCommands;
using CarBookApplication.Features.RepositoryPattern;
using CarBookApplication.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;
        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _repository.GetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCommant(Comment comment)
        {
            _repository.Create(comment);
            return Ok("Eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveComment(int id)
        {
            var value = _repository.GetById(id);
            _repository.Remove(value);
            return Ok("silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetComent(int id)
        {
            var value = _repository.GetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCommane(Comment comment)
        {
            _repository.Update(comment);
            return Ok("guncellendi");
        }
        [HttpGet("CommentListByBlog")]
        public IActionResult CommentListByBlog(int id)
        {
            var value = _repository.GetCommentsByBlogId(id);
            return Ok(value);
        }
        [HttpGet("GetCountCommentByBlogList")]
        public IActionResult GetCountCommentByBlogList(int id)
        {
            var value = _repository.GetCountCommentByBlog(id);
            return Ok(value);
        }
        [HttpPost("CreateCommentwithMediator")]
        public async Task<IActionResult> CreateCommentwithMediator(CreateCommentCommand command)
        {
             await _mediator.Send(command);
            return Ok("eklendi");
        }
    }
}
