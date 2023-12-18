﻿using LibraryInformationSystem.BLL.DTOs.Borrow;
using LibraryInformationSystem.BLL.Services.Contracts;
using LibraryInformationSystem.LibraryInformationSystem.BLL.DTOs.Book;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInformationSystem.API.Controllers
{
    [ApiController]
    [Route("api/borrow")]
    public class BorrowController : ControllerBase
    {
        private readonly IBorrowService _service;

        public BorrowController(IBorrowService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<BorrowGetDTO>> GetAllBorrows()
        {
            try
            {
                var borrows = await _service.GetAll();
                return Ok(borrows);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BorrowGetDTO>> GetBorrow(long id)
        {
            try
            {
                var borrow = await _service.GetById(id);
                return Ok(borrow);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult> AddBorrow(BorrowCreateDTO dto)
        {
            try
            {
                await _service.Create(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdeteBorrow(long id, BorrowUpdateDto dto)
        {
            try
            {
                await _service.Update(id, dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}