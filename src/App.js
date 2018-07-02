import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Kubernetes Demo</h1>
        </header>
        <p className="App-intro">
          <ul>
            <li><a href="https://crashy.demo.kubernetes.ninja">crashy</a> is a .net core application that is a little unstable</li>
            <li><a href="https://hungry.demo.kubernetes.ninja">hungry</a> is a java spring-boot application that eats a lot of CPU</li>
            <li><a href="https://leaky.demo.kubernetes.ninja">leaky</a> is a nodejs application that collects memories</li>
            <li><a href="https://chatty.demo.kubernetes.ninja">chatty</a> is a python application that produces lots of logs</li>
            <li><a href="https://proxy.demo.kubernetes.ninja">proxy</a> is a go reverse-proxy that can forward the other applications</li>
          </ul>
        </p>
      </div>
    );
  }
}

export default App;
