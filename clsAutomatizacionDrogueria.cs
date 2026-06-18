using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pryTesisVentas
{
    public class clsAutomatizacionDrogueria
    {
        public static async Task CargarPedidoEnWeb(string proveedor, List<clsDetallePedido> carrito)
        {
            // Cambiamos el using moderno por el clásico compatible con C# 7.3
            using (var playwright = await Playwright.CreateAsync())
            {
                var launchOptions = new BrowserTypeLaunchOptions { Headless = false };

                // Quitamos el 'await' de acá adelante para que no tire el error CS8370
                var browser = await playwright.Chromium.LaunchAsync(launchOptions);

                try
                {
                    var page = await browser.NewPageAsync();

                    if (proveedor.Contains("del Sud"))
                    {
                        // 1. Va a la web de la droguería
                        await page.GotoAsync("https://pedidos.delsud.com.ar/");

                        // 2. Completa el Login (Selectores de ejemplo para la tesis)
                        await page.FillAsync("#txtUsuario", "usuario_ejemplo_farmacia");
                        await page.FillAsync("#txtPassword", "clave123");
                        await page.ClickAsync("#btnIngresar");

                        // Esperamos que el login procese y cambie la URL
                        await page.WaitForURLAsync("**/inicio");

                        // 3. Recorre tu lista local cargando producto por producto en la página
                        foreach (clsDetallePedido item in carrito)
                        {
                            // Escribe el nombre del medicamento en el buscador de la web
                            await page.FillAsync("#buscador-productos-web", item.Producto);
                            await page.Keyboard.PressAsync("Enter");

                            // Espera que aparezca la casilla de cantidad de la web, pone el número y agrega
                            await page.WaitForSelectorAsync(".input-cantidad-drogueria");
                            await page.FillAsync(".input-cantidad-drogueria", item.Cantidad.ToString());
                            await page.ClickAsync(".btn-add-to-cart-web");
                        }

                        // 4. Deja al usuario en la pantalla del carrito web para el control final
                        await page.GotoAsync("https://pedidos.delsud.com.ar/");

                        // Espera 10 segundos antes de cerrar el navegador
                        await Task.Delay(10000);
                    }
                    else if (proveedor.Contains("Belleza"))
                    {
                        await page.GotoAsync("https://www.belleza-proveedor.com.ar/login");
                        // ... Lógica para el otro proveedor
                    }
                }
                finally
                {
                    // Como no pudimos usar 'await using', cerramos el navegador 
                    // de forma manual y segura acá adentro para C# 7.3
                    if (browser != null)
                    {
                        await browser.DisposeAsync();
                    }
                }
            }
        }
    }
}
