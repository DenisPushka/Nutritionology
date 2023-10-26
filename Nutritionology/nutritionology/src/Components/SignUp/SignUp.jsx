import {Component} from "react";
import Header from "../Header/Header";
import "./SignUp.css";
import Footer from "../Footer/Footer";

// Регистрация.
class SignUp extends Component {

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
        // физ/юр лицо.
        isCustomer: true
    };

    constructor(props) {
        super(props);

        this.getCustomer = this.getCustomer.bind(this);
        this.getCompany = this.getCompany.bind(this);

        this.postNewUser = this.postNewUser.bind(this);

        this.createNewUser = this.createNewUser.bind(this);
    }

    // Выбор физ лица.
    getCustomer(event) {
        event.preventDefault();

        this.setState({isCustomer: true});
    }

    // Выбор юр лица.
    getCompany(event) {
        event.preventDefault();

        this.setState({isCustomer: false});
    }

    async createNewUser() {
        if (this.state.isCustomer) {
            const form = document.getElementById("formForCustomer");

            this.state.customer.name = form.childNodes.item(1).value;
            this.state.customer.lastName = form.childNodes.item(3).value;
            this.state.user.email = form.childNodes.item(5).value;
            this.state.user.password = form.childNodes.item(7).value;
            this.state.user.photo = form.childNodes.item(9).value;
            this.state.user.phone = form.childNodes.item(11).value;
            // await this.setState({customer: {...this.state.customer.name, form: {...this.state.form.childNodes.item(1).value}}});
            // await this.setState({customer: {...this.state.customer.lastName, ...this.state.form.childNodes.item(3).value}});
            // this.setState({customer: {...this.state.user.email, ...this.form.childNodes.item(5).value}});
            // this.setState({customer: {...this.state.user.password, ...this.form.childNodes.item(7).value}});
        } else {
            const form = document.getElementById("formForCompany");

            this.state.company.name = form.childNodes.item(1).value;
            this.state.user.email = form.childNodes.item(3).value;
            this.state.user.password = form.childNodes.item(5).value;
            this.state.user.photo = form.childNodes.item(7).value;
            this.state.user.phone = form.childNodes.item(9).value;
            // await this.setState({customer: {...this.state.customer.name, form: {...this.state.form.childNodes.item(1).value}}});
            // await this.setState({customer: {...this.state.customer.lastName, ...this.state.form.childNodes.item(3).value}});
            // this.setState({customer: {...this.state.user.email, ...this.form.childNodes.item(5).value}});
            // this.setState({customer: {...this.state.user.password, ...this.form.childNodes.item(7).value}})
        }

        await this.postNewUser();
    }

    async postNewUser() {
        // let form = new FormData();
        // form.append(
        //     'user',
        //     {
        //         photo: this.state.user.photo,
        //         subscription: null,
        //         parameters: null,
        //         customer: this.state.customer,
        //         company: this.state.company
        //     });
        //
        // form.append('userRole', {name: "Customer"});
        let dictstring = JSON.stringify(
            {
                User: {
                    Photo: this.state.user.photo,
                    PhoneNumber: this.state.user.phone,
                    Customer: {
                        Name: this.state.customer.name,
                        LastName: this.state.customer.lastName
                    },
                    Company: {
                        Name: this.state.company.name
                    },
                    Email: this.state.user.email,
                    PasswordHash: this.state.user.password
                },
                Role: {Name: "Customer"}
            }
        );
        
        let jsonString = JSON.stringify(dictstring)
        console.log(jsonString)
        await fetch('/Account/SignIn', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            body: jsonString
        }).then().catch(err => console.log(err));
    }

    render() {
        return (
            <div>

                <Header/>

                <div className={"containerSignUp"}>

                    <div>
                        <button onClick={this.getCustomer}>
                            Физ лицо
                        </button>

                        <button onClick={this.getCompany}>
                            Юр лицо
                        </button>

                    </div>

                    {/*Для пользователя.*/}
                    {this.state.isCustomer &&
                        <form action="" id={"formForCustomer"} className={"formSignUp"}>
                            <div>
                                Имя:
                            </div>
                            <input type="text" id="formCustomerFirstName" required placeholder="Имя"/>

                            <div>
                                Фамилия:
                            </div>
                            <input type="text" id="formCustomerLastName" required placeholder="Фамилия"/>

                            <div>
                                Почта:
                            </div>
                            <input type="text" id="formCustomerEmail" required placeholder="qwert@mail.com"/>

                            <div>
                                Пароль:
                            </div>
                            <input type="text" id="formCustomerPassword" required placeholder="***"/>

                            <div>
                                Фото:
                            </div>
                            <input type="file" id="formCustomerPhoto" required placeholder=""/>

                            <div>
                                Телефон:
                            </div>
                            <input type="text" id="formCustomerPhone" required placeholder=""/>
                        </form>
                    }

                    {/*Для компании.*/}
                    {!this.state.isCustomer &&
                        <form action="" id={"formForCompany"} className={"formSignUp"}>
                            <div>
                                Название компании:
                            </div>
                            <input type="text" id="formCompanyName" required placeholder="Название"/>

                            <div>
                                Почта:
                            </div>
                            <input type="text" id="formCompanyEmail" required placeholder="Почта"/>

                            <div>
                                Пароль:
                            </div>
                            <input type="text" id="formCompanyPassword" required placeholder="***"/>

                            <div>
                                Фото:
                            </div>
                            <input type="file" id="formCompanyPhoto" required placeholder=""/>

                            <div>
                                Телефон:
                            </div>
                            <input type="text" id="formCompanyPhone" required placeholder=""/>
                        </form>
                    }

                    <button onClick={this.createNewUser}>
                        Отправить
                    </button>

                </div>

                <Footer/>
            </div>
        );
    }
}

export default SignUp;

// Что хочу добавить? 
// 1. Красивое отображение формы 
// 2. Чтобы при не заполнении нужных полей отправка запроса не проходила и пользователя уведомляли
// 3. 