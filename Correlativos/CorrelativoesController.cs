using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Correlativos
{
    public class CorrelativoesController : Controller
    {
        private  CorrelativoDBContext _context;

        public CorrelativoesController(CorrelativoDBContext context)
        {
            _context = context;
        }

        public static List<TipoDocumento> tiposDocumento { get; set; }
        public IActionResult Create()
        {
          
            tiposDocumento=_context.tipoDocumento.ToList<TipoDocumento>();
            Correlativo correlativo = new Correlativo();
            correlativo.tiposDocumento = tiposDocumento;
            return View(correlativo);
        }

        // POST: Correlativoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("monto", "descripcion")] Correlativo correlativo, [Bind("idTipDoc")] TipoDocumento tipoDocumento, [Bind("dni", "nombre")] Trabajador trabajador,string dni)
        {


            if (trabajador != null && trabajador.nombre != null && !trabajador.nombre.Equals(""))
            {
                Correlativo _correlativo = null;
                string codigo = null;
                int codigoentero = 1;

                

                if (_context.correlativo.Count()>0 
                    && _context.correlativo.Where(c => c.tipodocumento.idTipDoc == tipoDocumento.idTipDoc).Count() > 0
                    && _context.tipoDocumento.Where(t=>t.idTipDoc==tipoDocumento.idTipDoc).Count()>0)
                {
                    _correlativo = _context.correlativo.Where(c => c.tipodocumento.idTipDoc == tipoDocumento.idTipDoc).OrderBy(x => x.idCorrelativo).Last();
                    tipoDocumento = _context.tipoDocumento.Where(t => t.idTipDoc == tipoDocumento.idTipDoc).ToList<TipoDocumento>().Last();
                    if (_correlativo != null)
                    {
                        string prefijo_codigo = _correlativo.codigo;
                        int index = prefijo_codigo.IndexOf('-');
                        int length = prefijo_codigo.Length-2;
                        string [] codigo_array = prefijo_codigo.Split("-");
                        codigo = codigo_array[1];
                        codigoentero = Convert.ToInt32(codigo);
                        codigoentero++;

                        int digitos = (int)Math.Floor(Math.Log10(codigoentero) + 1);
                        if (digitos > 3)
                        {
                            codigo = "" + codigoentero;
                        }
                        else if (digitos > 2)
                        {
                            codigo = "0" + codigoentero;
                        }
                        else if (digitos > 1)
                        {
                            codigo = "00" + codigoentero;
                        }
                        else
                        {
                            codigo = "000" + codigoentero;
                        }

                        codigo = tipoDocumento.prefijo +"-"+codigo;
                    }
                }
                else if(_context.tipoDocumento.Where(t => t.idTipDoc == tipoDocumento.idTipDoc).Count() > 0)
                {
                    tipoDocumento = _context.tipoDocumento.Where(t => t.idTipDoc == tipoDocumento.idTipDoc).ToList<TipoDocumento>().Last();
                    codigo = tipoDocumento.prefijo+"-000" + codigoentero;
                }

             
                correlativo.codigo = codigo;

                

                if (_context.trabajador.Where(t => t.dni == trabajador.dni).Count() > 0)
                {
                    correlativo.trabajador = _context.trabajador.Where(t => t.dni == trabajador.dni).ToList<Trabajador>().Last();
                }
                else 
                {
                    correlativo.trabajador = new Trabajador(0,"","");
                    correlativo.tiposDocumento = tiposDocumento;
                    return View(correlativo);
                }

                if (tipoDocumento != null) { tipoDocumento = _context.tipoDocumento.Find(tipoDocumento.idTipDoc); }
                correlativo.tipodocumento = tipoDocumento;
          
                _context.Add(correlativo);
                await _context.SaveChangesAsync();

                Correlativo correlativoObject = _context.correlativo.ToList<Correlativo>().Last();
                correlativoObject.tiposDocumento = tiposDocumento;

                return View(correlativoObject);
            }
            else 
            {
                correlativo.tiposDocumento = tiposDocumento;
                if (_context.trabajador.Where(t => t.dni == trabajador.dni).Count() > 0)
                {
                    correlativo.trabajador = _context.trabajador.Where(t => t.dni == trabajador.dni).ToList<Trabajador>().Last();
                }
                else
                {
                    correlativo.trabajador = new Trabajador(0, "", "");
                    return View(correlativo);
                }
                return View(correlativo);
            }
            
        }

        

    }
}
