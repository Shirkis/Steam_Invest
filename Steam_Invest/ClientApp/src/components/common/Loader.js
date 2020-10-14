import React from 'react'
import { CircularProgress } from '@material-ui/core'
import styles from '../styles'

class Loader extends React.Component {
  constructor(props){
    super(props);
  }

  state = {
    visible: false
  }

  componentDidMount(){
    let { wait = 0 } = this.props;
    setTimeout(() => {
      this.setState({ visible: true })
    }, wait)
  }

  render() {
    const { style = {}, wait = 0 } = this.props;

    return (
      <div style={style} >
        {(this.state.visible || wait === 0) ? <CircularProgress/> : null}
      </div>
    )
  }
}
export default Loader