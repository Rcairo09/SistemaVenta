using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SistemaVenta.AplicacionWeb.Controllers;
using SistemaVenta.BLL.Implementacion;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVentaTest
{
    [TestFixture]

    public class Tests
    {
        private IProductoService servicioProducto;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            servicioProducto = new Mock<IProductoService>().Object;
            mapper = new Mock<IMapper>().Object;
        }

        [Test]
        public async Task Indice_DeberiaDevolverVista()
        {
            //Preparar
            var controlador = new ProductoController(mapper, servicioProducto);

            //Actuar
            var resultado = await controlador.Index();

            //Afirmar
            Assert.IsInstanceOf<IActionResult>(resultado);


        }

        [Test]
        public async Task Lista_DeberiaRetornarStatusCode200YDatosCorrectos()
        {
            //Preparar
            var controlador = new ProductoController(mapper, servicioProducto);

            //Actuar

            var resultado = await controlador.Lista() as ObjectResult;

            //Afirmar
            Assert.NotNull(resultado);
            Assert.AreEqual(StatusCodes.Status200OK, resultado.StatusCode);

        }

        [Test]
        public async Task Crear_Debe_Llamar_Al_ProductoService()
        {
            //Preparar
            var mockProductoService = new Mock<IProductoService>();
            var controlador = new ProductoController(Mock.Of<IMapper>(),mockProductoService.Object);

            //Actuar
            var modelo = "{\"Marca\": \"Toyota\", \"precio\": 12000}";
            var archivo = Mock.Of<IFormFile>();
            await controlador.Crear(archivo, modelo);
            //Afirmar
            mockProductoService.Verify(s => s.Crear(It.IsAny<Producto>(), It.IsAny<Stream>(),It.IsAny<String>()));


        }

        [Test]
        public async Task Eliminar_Debe_Llamar_Al_Producto()
        {
            //Preparar
            var mockProductoService = new Mock<IProductoService>();
            var controlador = new ProductoController(Mock.Of<IMapper>(), mockProductoService.Object);


            //Actuar

            await controlador.Eliminar(1);

            //Afirmar
            mockProductoService.Verify(s => s.Eliminar(1), Times.Once);
        }



    }
}