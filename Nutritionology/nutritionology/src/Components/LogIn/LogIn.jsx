import {Component} from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import "./LogIn.css";

// Атворизация.
class LogIn extends Component {

    state = {
        // Пользователь.
        user: {
            login: "",
            password: ""
        }
    };

    constructor(props) {
        super(props);
    }

    render() {
        return (<div>

            <Header/>
            
            <div>
                <form action="">
                    <div>
                        Логин
                    </div>
                    
                    <div>
                        Пароль
                    </div>
                </form>
            </div>
            
            <Footer/>
        </div>);
    }
}

export default LogIn