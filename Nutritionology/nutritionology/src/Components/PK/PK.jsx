import {Component} from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import "./PK.css";

// Личный кабинет.
class PK extends Component {

    state = {

        // Пользователь.
        user: {
            id: "",
            email: "",
            password: "",
            photo: null,
            subscription: {
                subscriptionId: "",
                name: "",
                price: 0
            },
            phone: ""
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
        
        type: "customer",

        // Парамаетры (Использовать объекты Parameter.js).
        parameters: []
    };

    constructor(props) {
        super(props);

        // TODO добавить редьюсер + запоминать пользователя и загружать сюда данные, если он определены.
    }

    componentDidMount() {
        // let responce = fetch('');
    }

    render() {
        return (
            <div>

                <Header/>

                <div className={"containerPK"}>

                    {/*Юр лицо.*/}
                    {
                        this.state.customer !== null && this.state.type === 'customer' &&
                        <div>
                            <div>
                                Имя: {this.state.customer.name}
                            </div>

                            <div>
                                Фамилия: {this.state.customer.lastName}
                            </div>

                        </div>
                    }

                    {/*Физ лицо.*/}
                    {
                        this.state.company !== null && this.state.type === 'company' &&
                        <div>
                            <div>
                                Название: {this.state.company.name}
                            </div>
                        </div>
                    }

                    {/* Общие данные.*/}
                    {
                        this.state.user !== null &&
                        <div>
                            <div>
                                Почта: {this.state.user.email}
                            </div>

                            <div>
                                Телефон: {this.state.user.phone}
                            </div>

                            <div>
                                Фото {this.state.user.photo}
                            </div>

                            Подписка:
                            <div>
                                {
                                    this.state.user.subscription !== null &&
                                    <div>
                                        <div>
                                            Название подписки: {this.state.user.subscription.name}
                                        </div>

                                        <div>
                                            Цена: {this.state.user.subscription.price}
                                        </div>
                                    </div>
                                }
                            </div>
                        </div>
                    }


                    Параметры

                    {this.state.parameters.length > 0 && this.state.parameters.map((parameter) => {
                        return (
                            <div>Пол: {parameter.gender.shortName}</div> &&
                            <div>Рост (см.): {parameter.height}</div> &&
                            <div>Вес (кг.): {parameter.weight}</div> &&
                            <div>Возраст: {parameter.age}</div> &&
                            <div>Любимые продукты: </div> &&

                            parameter.likeProducts.length > 0 && parameter.likeProducts.map((product) => {
                                return (
                                    <div>
                                        {product.fullName},
                                    </div>
                                );
                            }) &&
                            <div>Нежелательные продукты: </div> &&
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

                <Footer/>
            </div>
        );
    }
}

export default PK;