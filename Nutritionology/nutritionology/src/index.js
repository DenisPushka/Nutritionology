import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "./Components/Home/Home";
import SignUp from "./Components/SignUp/SignUp";
import PK from "./Components/PK/PK";
import LogIn from "./Components/LogIn/LogIn";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    // <Provider store={store}>
        <BrowserRouter>
            <Routes>
                <Route path="*" element={<Home/>}/>
                <Route path="/LogIn" element={<LogIn/>}/>
                <Route path="/SignUp" element={<SignUp/>}/>
                <Route path="/PK" element={<PK/>}/>
            </Routes>
        </BrowserRouter>
    // </Provider>
);

reportWebVitals();
