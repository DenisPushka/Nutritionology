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
        // физ/юр лицо.
        isCustomer: true
    };
    
    constructor(props) {
        super(props);
        
        this.getCustomer =this.getCustomer.bind(this);
        this.getCompany =this.getCompany.bind(this);
    }
    
    // Выбор физ лица.
    getCustomer(event) {
        event.preventDefault();
        
        this.setState({isCustomer: true });
    }
    
    // Выбор юр лица.
    getCompany(event) {
        event.preventDefault();
        
        this.setState({isCustomer: false });
    }
    
    render(){
        
        return(
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
                        <form action="">
                            <div>
                                Имя
                            </div>
                            
                            <div>
                                Фамилия
                            </div>
                            
                            <div>
                                Почта
                            </div>
                            
                            <div>
                                Пароль
                            </div>
                        </form>
                    }
    
                    {/*Для компании.*/}
                    {!this.state.isCustomer &&
                        <form action="">
                            <div>
                                Название компании
                            </div>
                            
                            <div>
                                Почта
                            </div>
    
                            <div>
                                Пароль
                            </div>
                        </form>
                    }
                    
                    <button>
                        Отправить
                    </button>

                </div>
                
                <Footer/>
            </div>  
        )
    }
}

export default SignUp;