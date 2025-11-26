using Application.DTOs.TagDTOs;
using Application.Interfaces.Irepositories;
using Application.Services;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace chas_happenings.Tests.Services
{
    public class TagServicesTests
    {
        // -----------------------------
        // TEST: AddTagServiceAsync Success
        // -----------------------------
        [Fact]
        public async Task AddTagServiceAsync_ReturnsNewId_WhenRepoReturnsTag()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            var tagToReturn = new Tag { Id = 5, TagName = "Sports" };

            mockRepo.Setup(r => r.AddTagRepoAsync(It.IsAny<Tag>()))
                    .ReturnsAsync(tagToReturn);

            var service = new TagServices(mockRepo.Object);

            // Act
            var result = await service.AddTagServiceAsync(new CreateTagDTO { TagName = "Sports" });

            // Assert
            Assert.Equal(5, result);
        }

        // -----------------------------
        // TEST: AddTagServiceAsync Throws
        // -----------------------------
        [Fact]
        public async Task AddTagServiceAsync_ThrowsInvalidOperation_WhenRepoReturnsNull()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.AddTagRepoAsync(It.IsAny<Tag>())).ReturnsAsync((Tag?)null);

            var service = new TagServices(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                service.AddTagServiceAsync(new CreateTagDTO { TagName = "Sports" }));
        }

        // -----------------------------
        // TEST: DeleteTagByIdServiceAsync Success
        // -----------------------------
        [Fact]
        public async Task DeleteTagByIdServiceAsync_ReturnsCount_WhenTagExists()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.GetTagByIdRepoAsync(1))
                    .ReturnsAsync(new Tag { Id = 1, TagName = "Sports" });
            mockRepo.Setup(r => r.DeleteTagByIdRepoAsync(1))
                    .ReturnsAsync(1);

            var service = new TagServices(mockRepo.Object);

            // Act
            var result = await service.DeleteTagByIdServiceAsync(1);

            // Assert
            Assert.Equal(1, result);
        }

        // -----------------------------
        // TEST: DeleteTagByIdServiceAsync Throws
        // -----------------------------
        [Fact]
        public async Task DeleteTagByIdServiceAsync_ThrowsKeyNotFound_WhenTagMissing()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.GetTagByIdRepoAsync(99))
                    .ReturnsAsync((Tag?)null);

            var service = new TagServices(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.DeleteTagByIdServiceAsync(99));
        }

        // -----------------------------
        // TEST: GetAllTagsServiceAsync
        // -----------------------------
        [Fact]
        public async Task GetAllTagsServiceAsync_ReturnsTagList()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            var tags = new List<Tag?>
            {
                new Tag { Id = 1, TagName = "Tag A" },
                new Tag { Id = 2, TagName = "Tag B" }
            };

            mockRepo.Setup(r => r.GetAllTagsRepoAsync()).ReturnsAsync(tags);

            var service = new TagServices(mockRepo.Object);

            // Act
            var result = await service.GetAllTagsServiceAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, t => t.TagName == "Tag A");
            Assert.Contains(result, t => t.TagName == "Tag B");
        }

        // -----------------------------
        // TEST: GetTagByIdServiceAsync Success
        // -----------------------------
        [Fact]
        public async Task GetTagByIdServiceAsync_ReturnsTag_WhenExists()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.GetTagByIdRepoAsync(1))
                    .ReturnsAsync(new Tag { Id = 1, TagName = "Sports" });

            var service = new TagServices(mockRepo.Object);

            // Act
            var result = await service.GetTagByIdServiceAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Sports", result.TagName);
        }

        // -----------------------------
        // TEST: GetTagByIdServiceAsync Throws
        // -----------------------------
        [Fact]
        public async Task GetTagByIdServiceAsync_ThrowsKeyNotFound_WhenMissing()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.GetTagByIdRepoAsync(99)).ReturnsAsync((Tag?)null);

            var service = new TagServices(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.GetTagByIdServiceAsync(99));
        }

        // -----------------------------
        // TEST: UpdateTagServiceAsync Success
        // -----------------------------
        [Fact]
        public async Task UpdateTagServiceAsync_ReturnsCount_WhenTagExists()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            var existingTag = new Tag { Id = 1, TagName = "Old Name" };

            mockRepo.Setup(r => r.GetTagByIdRepoAsync(1)).ReturnsAsync(existingTag);
            mockRepo.Setup(r => r.UpdateTagRepoAsync(It.IsAny<Tag>())).ReturnsAsync(1);

            var service = new TagServices(mockRepo.Object);

            // Act
            var result = await service.UpdateTagServiceAsync(1, new UpdateTagDTO { TagName = "New Name" });

            // Assert
            Assert.Equal(1, result);
            Assert.Equal("New Name", existingTag.TagName);
        }

        // -----------------------------
        // TEST: UpdateTagServiceAsync Throws
        // -----------------------------
        [Fact]
        public async Task UpdateTagServiceAsync_ThrowsKeyNotFound_WhenTagMissing()
        {
            // Arrange
            var mockRepo = new Mock<ITagRepositories>();
            mockRepo.Setup(r => r.GetTagByIdRepoAsync(99)).ReturnsAsync((Tag?)null);

            var service = new TagServices(mockRepo.Object);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() =>
                service.UpdateTagServiceAsync(99, new UpdateTagDTO { TagName = "New Name" }));
        }
    }
}
