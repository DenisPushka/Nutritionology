import {Component} from "react";
import Header from "../Header/Header";
import ".//Home.css";
import Footer from "../Footer/Footer";

// Главная (Домашняя страница).
class Home extends Component {

    constructor(props) {
        super(props);
    }    

    render() {
        return (
            <div>
                <Header/>

                <body>
                <div className={"container_body"}>

                    <div>
                        <b className={"subTittle"}>Дни недели</b>

                        <div className={"blocks"}>
                            <div className={"block"}>ПН</div>
                            <div className={"block"}>ВТ</div>
                            <div className={"block"}>СР</div>
                            <div className={"block"}>ЧТ</div>
                            <div className={"block"}>ПТ</div>
                            <div className={"block"}>СБ</div>
                            <div className={"block"}>ВС</div>

                        </div>
                        <hr/>

                    </div>

                    <div>
                        <b className={"subTittle"}> Время еды </b>

                        <div className={"blocks"}>
                            <div className={"block"}>Завтрак</div>
                            <div className={"block"}>Обед</div>
                            <div className={"block"}>Полдник</div>
                            <div className={"block"}>Ужин</div>
                            <div className={"block"}>Сонник</div>
                        </div>

                        <hr/>
                    </div>

                    <div>
                        <b className={"subTittle"}> Блюдо </b>

                        <div className={"blocks"} c>
                            <div className={"block"}>Крем-суп + напиток</div>
                            <div className={"block"}>Салат + напиток</div>
                            <div className={"block"}>Горячее + напиток</div>
                        </div>

                        <hr/>
                    </div>

                    <div>
                        <b className={"subTittle"}> Выберите команию</b>
                        <div className={"blocks"}>
                            <div className={"block"}>Компания</div>
                            <div className={"block"}>Компания</div>
                            <div className={"block"}>Компания</div>
                        </div>
                    </div>
                </div>
                </body>
                
                <Footer/>
            </div>
        );
    }
}

export default Home