using System;
using System.Net.Http;
using Xunit;
using Moq;
using Project2;
using WebAPI.Controllers;
using WebAPI;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Interfaces;
using WebAPI.Repositories;
using WebAPI.DataTransferObjects;
using System.Collections.Generic;

namespace XUnitTest
{  
    
    public class WebserviceTests
    {
        [Fact]
        public void GetQuestionWithAnswersByPostId_returns_ListOfDTO()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetQuestionWithAnswersByPostId(It.IsAny<int>())).Returns(new List<Post>());
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetQuestionWithAnswersByPostId(19);

            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public void GetQuestionWithAnswersByPostId_INvalidID ()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetQuestionWithAnswersByPostId(It.IsAny<int>())).Returns((List<Post>)null);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetQuestionWithAnswersByPostId(17);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Marked_with_validID()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.MarkPost(It.IsAny<int>())).Returns(true);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.MarkPost(19);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Marked_with_invalidID()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.MarkPost(It.IsAny<int>())).Returns(false);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.MarkPost(19);

            Assert.IsType<NotFoundResult>(response);
        }
        [Fact]
        public void Annotation_valid()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetAnnotation(It.IsAny<int>())).Returns(new Post().Annotation);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetAnnotation(19);

            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public void Annotation_none()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetAnnotation(It.IsAny<int>())).Returns("No annotation for this post.");
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetAnnotation(19);

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void Annotation_update()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.UpdateAnnotation(It.IsAny<int>(), "this is awesome")).Returns(true);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.UpdateAnnotation(19, "this is awesome");

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void Annotation_failedupdate()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.UpdateAnnotation(It.IsAny<int>(), "")).Returns(false);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.UpdateAnnotation(19, "");

            Assert.IsType<NotFoundResult>(response);
        }

        [Fact]
        public void GetPostsBySearchString()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetPostsBySearchString("sql", It.IsAny<int>(), It.IsAny<int>())).Returns(new List<Post>());
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetPostsBySearchString("sql", 17, 19);

            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public void GetPostsBySearchString_invalid()
        {
            var dataServiceMock = new Mock<IDataService>();
            dataServiceMock.Setup(o => o.PostRepository.GetPostsBySearchString("", It.IsAny<int>(), It.IsAny<int>())).Returns((List<Post>)null);
            var urlHelperMock = new Mock<IUrlHelper>();

            var ctrl = new PostController(dataServiceMock.Object);
            ctrl.Url = urlHelperMock.Object;

            var response = ctrl.GetPostsBySearchString("", 0, 0);

            Assert.IsType<NotFoundResult>(response);
        }
    }
}
