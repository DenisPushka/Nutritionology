import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import reportWebVitals from './reportWebVitals';
import {BrowserRouter, Route, Routes} from "react-router-dom";
import Home from "./Components/Home/Home";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    // <Provider store={store}>
        <BrowserRouter>
            <Routes>
                <Route path="*" element={<Home/>}/>
            </Routes>
        </BrowserRouter>
    // </Provider>
);

reportWebVitals();
