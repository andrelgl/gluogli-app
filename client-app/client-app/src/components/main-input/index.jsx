import React from 'react'
import style from './style.module.scss'
import { withRouter } from "react-router";

const axios = require('axios');
class MainInput extends React.Component {

    constructor(props) {
        super(props);
        this.state = [];
    }

    search = () => {
        console.log("Cliquei");
        let result = document.getElementById('textbox').value;
        axios.get(`http://localhost:5000/api/search?query=${result}`)
            .then((response) => {
                console.log("Respondi");
                console.log(response);
                this.props.history.push("/result", response.data)
            });
    }
    //<Link to="/result">
    render() {
        return (
            <div className={style.Form}>
                <input id="textbox" className={style.InputText} type="text" />
                <div className={style.Button}>
                   <button onClick={this.search} className={style.ButtonBuscar}>Buscar</button>
                </div>
            </div>
        );
    }
}
export default withRouter(MainInput)