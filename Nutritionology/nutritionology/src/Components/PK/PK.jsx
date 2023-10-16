import {Component} from "react";
import Parameter from "../../Models/Parameter";

// Личный кабинет.
class PK extends Component {

    state = {

        // Пользователь.
        user: {
            id: "",
            email: "",
            password: ""
        },

        // Физ. лицо.
        customer: {
            customerId: "",
            name: "",
            lastName: ""
        },

        // Юр. лицо.
        company: {
            companyId: "",
            name: ""
        },

        // Парамаетры (Испольховать объекты Parameter.js).
        parameters: []
    };

    constructor(props) {
        super(props);
        
        // this.setState({parameters: new Parameter[1]});

        // TODO добавить редьюсер + запоминать пользователя и загружать сюда данные, если он определены.
    }

    render() {
        return (
            <div>

                <div>
                    Параметры

                    {this.state.parameters.length > 0 && this.state.parameters.map((parameter) => {
                        return (
                            <div>Пол: {parameter.gender.shortName}</div>,
                                <div>Рост (см.): {parameter.height}</div>,
                                <div>Вес (кг.): {parameter.weight}</div>,
                                <div>Возраст: {parameter.age}</div>,
                                <div>Любимые продукты: </div>,

                            parameter.likeProducts.length > 0 && parameter.likeProducts.map((product) => {
                                return (
                                    <div>
                                        {product.fullName},
                                    </div>
                                );
                            }),
                                <div>Нежелательные продукты: </div>,
                            parameter.problemProducts.length > 0 && parameter.problemProducts.map((product) => {
                                return (
                                    <div>
                                        {product.fullName},
                                    </div>
                                );
                            })
                        );
                    })}
                </div>
            </div>
        );
    }
}

export default PK;