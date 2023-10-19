using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieApp.Controllers;
using MovieApp.Interfaces;
using MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreTests.Controllers
{
    public class MovieControllerTests
    {
        private Mock<IMovieViewModelService> _mockMovieService;

        private MoviesController _sut;

        List<MovieViewModel> data = new()
        {
            new MovieViewModel { Id = 1, ReleaseYear = new DateTime(2006,1,1), Title = "Very Real Movie", Genre = MovieApp.Enums.Genre.Comedy },
            new MovieViewModel { Id = 2, ReleaseYear = new DateTime(2020,1,1), Title = "Very Real Movie 2", Genre = MovieApp.Enums.Genre.Tragedy },
            new MovieViewModel { Id = 3, ShortDescription = "Just your typical romance.", Title = "Something, something Love", Genre = MovieApp.Enums.Genre.Romance },
            new MovieViewModel { Id = 4, Title = ".gitignore: The Movie", Genre = MovieApp.Enums.Genre.Horror }
        };

        public MovieControllerTests()
        {
            _mockMovieService = new Mock<IMovieViewModelService>();
            _sut = new MoviesController(_mockMovieService.Object);

            _mockMovieService.Setup(r => r.GetAllMovies()).Returns(() => data.AsEnumerable());
            _mockMovieService.Setup(r => r.GetMovieById(It.IsAny<int>()))
                .Returns((int id) => data.FirstOrDefault(d => d.Id == id));
            _mockMovieService.Setup(r => r.AddMovie(It.IsAny<MovieViewModel>()))
                .Callback(() => { return; });
        }

        [Fact]
        public void Index_NoInput_ReturnsAView()
        {
            // Arrange & Act
            ViewResult result = _sut.Index() as ViewResult;
            var model = result.Model as List<MovieViewModel>;

            // Assert
            result.Should().NotBeNull();
            model.Should().NotBeNull();
            model.Should().HaveCount(4);
        }

        [Fact]
        public void Details_InvalidId_ReturnsNotFoundView()
        {
            // Arrange
            var idnotInRepository = 5;

            // Act
            ViewResult result = _sut.Details(idnotInRepository) as ViewResult;

            // Assert
            result.Should().NotBeNull();
            result.ViewName.Should().Be("NotFound");
            result.Model.Should().BeNull();
        }

        [Fact]
        public void Details_ValidId_ReturnsDetailsView()
        {
            // Arrange
            var movie = this.data[1];

            // Act
            ViewResult result = _sut.Details(movie.Id) as ViewResult;
            var model = result.Model as MovieViewModel;

            // Assert
            result.Should().NotBeNull();
            result.Model.Should().NotBeNull();
            model.Id.Should().Be(movie.Id);
            model.Genre.Should().Be(movie.Genre);
            model.ReleaseYear.Should().Be(movie.ReleaseYear);
            model.ShortDescription.Should().Be(movie.ShortDescription);
            model.Title.Should().Be(movie.Title);
        }

        [Fact]
        public void Create_NoInput_ReturnsIndexView()
        {
            // Arrange and Act
            ViewResult result = _sut.Create() as ViewResult;

            // Assert
            result.Should().NotBeNull();
        }
    }
}