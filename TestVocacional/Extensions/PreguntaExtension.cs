using System.Linq;
using TestVocacional.Model;

namespace TestVocacional.Extensions
{
    public static class PreguntaExtension
    {
        public static List<string> VerificarRespuestas(this List<Pregunta> preguntas, List<Interes> listaintereses)
        {
            return preguntas
                .Select(pregunta => pregunta.ID.VerificarDiccionario(listaintereses))
                .Where(letra => letra != null)
                .GroupBy(letra => letra)
                .OrderByDescending(grupo => grupo.Count())
                .Take(2)
                .Select(grupo => grupo.Key)
                .ToList();
        }
        
        public static string VerificarDiccionario(this int id, List<Interes> listaintereses)
        {
            foreach(var inters in listaintereses)
            {
                if (inters.idpreguntas.Contains(id))
                    return inters.ID;
            }

            return "";
        }
    }
}
