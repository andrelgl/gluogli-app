import React from 'react'
import style from './style.module.scss'
import Helmet from 'react-helmet'

import MainInput from '../../components/main-input/index'

export default class Home extends React.Component {


    render() {
        return (
            <div className={style.Home}>
            <Helmet title="Glougli" />
                <div className={style.Gougli}>
                    Glougli
                </div>
                <div className={style.Input}>
                    <MainInput />
                </div>
            </div>
        )
    }
} 