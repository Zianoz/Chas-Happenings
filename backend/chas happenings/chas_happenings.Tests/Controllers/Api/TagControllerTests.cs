using Application.DTOs.TagDTOs;
using Application.Interfaces.IServices;
using chas_happenings.Controllers.Api;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chas_happenings.Tests.Controllers.Api
{
    public class TagControllerTests
    {
        // -----------------------------
        // TEST 1: CreateTag success
        // -----------------------------
        [Fact]
        public async Task CreateTag_ReturnsOk_WhenTagCreated()
        {
            // Arrange
            var mockService = new Mock<ITagServices>();
            mockService
                .Setup(s => s.AddTagServiceAsync(It.IsAny<CreateTagDTO>()))
                .ReturnsAsync(5); // pretend new tag ID is 5

            var controller = new TagController(mockService.Object);

            // Act
            var result = await controller.CreateTag(new CreateTagDTO());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(5, okResult.Value);
        }

        // -----------------------------
        // TEST 2: CreateTag fails
        // -----------------------------
        [Fact]
        public async Task CreateTag_ReturnsBadRequest_WhenTagNotCreated()
        {
            // Arrange
            var mockService = new Mock<ITagServices>();
            mockService
                .Setup(s => s.AddTagServiceAsync(It.IsAny<CreateTagDTO>()))
                .ReturnsAsync(0);

            var controller = new TagController(mockService.Object);

            // Act
            var result = await controller.CreateTag(new CreateTagDTO());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        // -----------------------------
        // TEST 3: GetTagById success
        // -----------------------------
        [Fact]
        public async Task GetTagById_ReturnsOk_WhenTagExists()
        {
            // Arrange
            var mockService = new Mock<ITagServices>();
            mockService
                .Setup(s => s.GetTagByIdServiceAsync(1))
                .ReturnsAsync(new Tag { Id = 1, TagName = "Sports" });

            var controller = new TagController(mockService.Object);

            // Act
            var result = await controller.GetTagById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var tag = Assert.IsType<Tag>(okResult.Value);

            Assert.Equal(1, tag.Id);
            Assert.Equal("Sports", tag.TagName);
        }

        // -----------------------------
        // TEST 4: GetTagById returns NotFound
        // -----------------------------
        [Fact]
        public async Task GetTagById_ReturnsNotFound_WhenTagMissing()
        {
            // Arrange
            var mockService = new Mock<ITagServices>();
            mockService
                .Setup(s => s.GetTagByIdServiceAsync(99))
                .ReturnsAsync((Tag?)null);

            var controller = new TagController(mockService.Object);

            // Act
            var result = await controller.GetTagById(99);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result.Result);
        }

        // -----------------------------
        // TEST 5: GetAllTags
        // -----------------------------
        [Fact]
        public async Task GetAllTags_ReturnsOk_WithTagList()
        {
            var mockService = new Mock<ITagServices>();
            var sampleTags = new List<Tag>
            {
                new Tag { Id = 1, TagName = "Tag A" },
                new Tag { Id = 2, TagName = "Tag B" }
            };

            mockService.Setup(s => s.GetAllTagsServiceAsync())
                       .ReturnsAsync(sampleTags);

            var controller = new TagController(mockService.Object);

            var result = await controller.GetAllTags();
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var returnedTags = Assert.IsType<List<Tag>>(ok.Value);

            Assert.Equal(2, returnedTags.Count);
        }

        // -----------------------------
        // TEST 6: UpdateTag - Success
        // -----------------------------
        [Fact]
        public async Task UpdateTag_ReturnsOk_WhenUpdateSucceeds()
        {
            var mockService = new Mock<ITagServices>();
            mockService.Setup(s => s.UpdateTagServiceAsync(1, It.IsAny<UpdateTagDTO>()))
                       .ReturnsAsync(1);

            var controller = new TagController(mockService.Object);

            var result = await controller.UpdateTag(1, new UpdateTagDTO());

            Assert.IsType<OkObjectResult>(result);
        }

        // -----------------------------
        // TEST 7: UpdateTag - Fail
        // -----------------------------
        [Fact]
        public async Task UpdateTag_ReturnsBadRequest_WhenUpdateFails()
        {
            var mockService = new Mock<ITagServices>();
            mockService.Setup(s => s.UpdateTagServiceAsync(1, It.IsAny<UpdateTagDTO>()))
                       .ReturnsAsync(0);

            var controller = new TagController(mockService.Object);

            var result = await controller.UpdateTag(1, new UpdateTagDTO());

            Assert.IsType<BadRequestObjectResult>(result);
        }

        // -----------------------------
        // TEST 8: DeleteTag - Success
        // -----------------------------
        [Fact]
        public async Task DeleteTag_ReturnsOk_WhenDeleteSucceeds()
        {
            var mockService = new Mock<ITagServices>();
            mockService.Setup(s => s.DeleteTagByIdServiceAsync(1))
                       .ReturnsAsync(1);

            var controller = new TagController(mockService.Object);

            var result = await controller.DeleteTag(1);

            Assert.IsType<OkObjectResult>(result);
        }

        // -----------------------------
        // TEST 9: DeleteTag - NotFound
        // -----------------------------
        [Fact]
        public async Task DeleteTag_ReturnsNotFound_WhenTagMissing()
        {
            var mockService = new Mock<ITagServices>();
            mockService.Setup(s => s.DeleteTagByIdServiceAsync(99))
                       .ReturnsAsync(0);

            var controller = new TagController(mockService.Object);

            var result = await controller.DeleteTag(99);

            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
