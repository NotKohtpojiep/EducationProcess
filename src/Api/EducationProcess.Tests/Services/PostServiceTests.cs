using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using EducationProcess.DataAccess;
using EducationProcess.DataAccess.Repositories.Interfaces;
using EducationProcess.Domain.Models;
using EducationProcess.Services;
using EducationProcess.Services.Services;
using FluentAssertions;
using Moq;
using Xunit;

namespace EducationProcess.Tests.Services
{
    public class PostServiceTests
    {
        private readonly Mock<IPostRepository> _postRespositoryMock;
        private readonly PostService _service;

        public PostServiceTests()
        {
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            _postRespositoryMock = new Mock<IPostRepository>();

            unitOfWorkMock.Setup(x => x.Posts)
                .Returns(_postRespositoryMock.Object);

            var servicesMappingProfile = new ServicesMappingProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(servicesMappingProfile));
            IMapper mapper = new Mapper(configuration);

            _service = new PostService(unitOfWorkMock.Object, mapper);
        }

        [Fact]
        public async Task Add_PostIsValid_ShouldAddNewPost()
        {
            // arrange
            var fixture = new Fixture();

            var expectedPostId = fixture.Create<int>();

            var post = fixture.Build<Post>()
                .Without(x => x.PostId)
                .Create();

            var expectedEntityPost = new DataAccess.Entities.Post()
            {
                PostId = expectedPostId,
                Name = post.Name
            };

            _postRespositoryMock.Setup(x => x.AddAsync(It.IsAny<DataAccess.Entities.Post>()))
                .ReturnsAsync(expectedEntityPost);

            // act
            var result = await _service.AddPostAsync(post);

            // assert
            result.PostId.Should().Be(expectedPostId);
            _postRespositoryMock.Verify(x => x.AddAsync(It.IsAny<DataAccess.Entities.Post>()), Times.Once);
        }
    }
}