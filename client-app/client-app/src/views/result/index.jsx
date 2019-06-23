import React from 'react'
import style from './style.module.scss'
import Helmet from 'react-helmet'
import {withRouter} from 'react-router'
import mock from './site.json'


class Result extends React.Component {
    constructor(props) {
        super(props);
        this.state = props;
    }
    render() {
        // pecorre os props e faz redenrizar
        const listResults = this.state.history.location.state.map(i => {
            return (
                <div className={style.SiteBox}>
                    <a href={i.link} key={i.titulo} rel="noopener noreferrer" className={style.Title}>{i.titulo}</a>
                    <a key={i.link} className={style.Link}>{i.link}</a>
                </div>
            )
        });
        const enptyResults = () => (
            <div>hellow</div>
        );

        // realiza uma nova busca
        let search = () => {
            let text = document.querySelector("input").value;
            if (text.length > 0) {
                console.log(this.state)
            }
        }

        // retorna a interface
        return (
            <div className={style.Result}>
            <Helmet title="Glougli - Resultado da busca" />
                <div className={style.Header}>
                    <a href="javascript:history.back()" className={style.Gougli}>
                        Glougli
                    </a>
                    <input className={style.Input} type="text" />
                    <button className={style.HeaderButton} onClick={search}>Buscar</button>
                </div>
                <div className={style.Body}>
                    {mock.length > 0 ?listResults:enptyResults}
                </div>
            </div>
        )
    }
}

export default withRouter(Result);