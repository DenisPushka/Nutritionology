class Parameter {

    // Id.
    parameterId = "";

    // Пол.
    gender = {
        genderId: "",
        shortName: "",
        fullName: ""
    }

    // Вес (кг).
    weight = 0;

    // Рост (см).
    height = 0;

    // Возраст.
    age = 0;

    // Любимые продукты (использовать объекты Product.js).
    likeProducts = [];

    // Проблемные продукты (использовать объекты Product.js).
    problemProducts = [];
}

export default Parameter