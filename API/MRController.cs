using DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Nutritionology;

namespace API
{
    /// <summary>
    /// Контроллер для взаимодействия с Таблицей "Методические рекомендации".
    /// </summary>
    [ApiController, Route("[controller]")]
    public class MRController : ControllerBase
    {
        /// <summary>
        /// Репозиторий МР и всех прилегающих с ней словарей (Элемент МР, СИ, Биологический элемент).
        /// </summary>
        private readonly IMRRepository _mrRepository;

        public MRController(IMRRepository mrRepository) => _mrRepository = mrRepository;

        #region СИ

        /// <summary>
        /// Добавление массива СИ.
        /// </summary>
        /// <param name="mses">Добавляемый объект.</param>
        /// <returns>Массив всех объектов СИ.</returns>
        [HttpPost, Route("AddArrayMs")]
        public async Task<IActionResult> AddMsArray([FromBody] MeasurementSystem[] mses) =>
            Ok(await _mrRepository.AddArrayMs(mses));

        /// <summary>
        /// Добавление объекта СИ.
        /// </summary>
        /// <param name="ms">Добавляемый объект.</param>
        /// <returns>Массив всех объектов СИ.</returns>
        // TODO РАЗОБРАТЬСЯ С FROMFORM/FROMBODY.
        [HttpPost, Route("AddMs")]
        public async Task<IActionResult> AddMs([FromForm] MeasurementSystem ms) => Ok(await _mrRepository.AddMs(ms));

        /// <summary>
        /// Получение всех единиц измерений.
        /// </summary>
        /// <returns>Массив всех объектов СИ.</returns>
        [HttpGet, Route("GetAllMs")]
        public async Task<IActionResult> GetAllMs() => Ok(await _mrRepository.GetAllMs());

        #endregion

        /// <summary>
        /// Получение всех биологических элементов.
        /// </summary>
        /// <returns>Массив всех биологических элементов.</returns>
        [HttpGet, Route("GetBLs")]
        public async Task<BiologicalElement[]> GetBiologicallyElements() =>
            await _mrRepository.GetBiologicallyElements();

        #region Элемент МР

        /// <summary>
        /// Добавление элемента МР.
        /// </summary>
        /// <param name="mrItem">Добавляемый объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        [HttpPost, Route("AddMrItem")]
        public async Task<MRItem[]> AddMrItem([FromBody] MRItem mrItem) => await _mrRepository.AddMrItem(mrItem);

        /// <summary>
        /// Добавление массива элементов МР.
        /// </summary>
        /// <param name="mrItems">Добавляемый объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        [HttpPost, Route("AddMrItems")]
        public async Task<MRItem[]> AddMrItems(/*[FromBody]*/ MRItem[] mrItems) => await _mrRepository.AddMrItems(mrItems);

        /// <summary>
        /// Изменение элемента МР.
        /// </summary>
        /// <param name="mrItem">Измененный объект.</param>
        /// <returns>Массив всех элементов МР.</returns>
        [HttpPut, Route("UpdateMrItem")]
        public async Task<MRItem[]> UpdateMrItems([FromBody] MRItem mrItem) =>
            await _mrRepository.UpdateMrItem(mrItem);

        /// <summary>
        /// Получение всех объектов МР.
        /// </summary>
        /// <returns>Массив всех объектов МР.</returns>
        [HttpGet, Route("GetMRItems")]
        public async Task<IActionResult> GetMrItems() => Ok(await _mrRepository.GetMrItems());

        #endregion

        #region МР

        /// <summary>
        /// Добавление МР.
        /// </summary>
        /// <param name="mr">Добавляемая МР.</param>
        /// <returns>Массив всех МР.</returns>
        [HttpPost, Route("AddMr")]
        public async Task<MR[]> AddMr([FromBody] MR mr) => await _mrRepository.AddMr(mr);

        /// <summary>
        /// Добавление массива МР.
        /// </summary>
        /// <param name="mrs">Добавляемый объект.</param>
        /// <returns>Массив всех МР.</returns>
        [HttpPost, Route("AddMrs")]
        public async Task<MR[]> AddMrs([FromBody] MR[] mrs) => await _mrRepository.AddMrs(mrs);

        /// <summary>
        /// Изменение МР.
        /// </summary>
        /// <param name="mr">Измененный объект.</param>
        /// <returns>Массив всех МР.</returns>
        [HttpPut, Route("UpdateMr")]
        public async Task<MR[]> AddMrs([FromBody] MR mr) => await _mrRepository.UpdateMr(mr);

        /// <summary>
        /// Получение всех МР.
        /// </summary>
        /// <returns>Массив всех МР.</returns>
        [HttpGet, Route("GetMRs")]
        public async Task<IActionResult> GetMRs() => Ok(await _mrRepository.GetMrs());

        #endregion
    }
}