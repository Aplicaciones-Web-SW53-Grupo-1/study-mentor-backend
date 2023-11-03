using _3._Data;
using _3._Data.Model;

namespace _2._Domain
{
    public class ScoreDomain : IScoreDomain
    {
        private IScoreData _scoreData;

        public ScoreDomain(IScoreData scoreData)
        {
            _scoreData = scoreData;
        }

        public bool Create(Score score)
        {
            if (score == null)
            {
                // Validar si el objeto Score es nulo
                return false;
            }

            if (string.IsNullOrWhiteSpace(score.Type))
            {
                // Validar si el campo "Type" no está vacío o es nulo
                return false;
            }

            if (string.IsNullOrWhiteSpace(score.Date))
            {
                // Validar si el campo "Date" no está vacío o es nulo
                return false;
            }

            // Realiza más validaciones según tus requisitos
            // Por ejemplo, validar el formato de la fecha y el puntaje

            // Si todas las validaciones pasan, puedes llamar al método Create en la capa de datos
            bool created = _scoreData.Create(score);

            return created;
        }
    }
}