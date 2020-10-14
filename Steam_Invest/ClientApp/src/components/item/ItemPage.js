import React from 'react'
// import Header from 'components/headers/Header'
// import Subheader from 'components/headers/Subheader'
// import Footer from 'components/footer/Footer'
import { withStyles, AppBar, Tabs, Tab } from '@material-ui/core'
// import { withRouter, Redirect } from 'react-router-dom'
import { connect } from 'react-redux'
import styles from '../styles'
import classnames from 'classnames'
import Item from './Item'
import { getItemsForPortfolio } from '../../actions/item'

function TabContainer(props) {
  return (
    <div
      className="main-section"
      style={{ paddingTop: 24, backgroundColor: '#f6f6f6' }}
    >
      {props.children}
    </div>
  )
}

class ItemPage extends React.Component {

  handleChange = (event, value) => {
      this.props.history.push(`/item/${value}`);
  }

  componentDidMount() {
    this.props.getItemsForPortfolio();
  }

  openDialog() {
    this.setState({ dialogOpened: true });
  }

  render() {
    const { classes } = this.props
    const section = "item"; //const { section = "item" } = this.props.match.params;

    return (
      <div>
        {/* <Header /> */}
        {/* <Subheader title="Портфели" /> */}
        <section>
          <AppBar
            position="static"
            className="AppBar"
            style={{ backgroundColor: '#fff', paddingBottom: 0 }}
          >
            <Tabs
              value={section}
              onChange={this.handleChange}
              className={classes.tabs}
              indicatorColor="primary"
              textColor="primary"
              classes={{
                root: classes.rootInherit
              }}
            >
              <Tab
                label="Предметы"
                value="item"
                textColor="primary"
                classes={{
                  label: classnames(classes.button, 'Wrapless'),
                  labelContainer: classes.tabButton,
                  wrapper: classes.tabButton,
                  selected: classes.bc,
                  root: classes.rootTabPrimary
                }}
              />
              {/* <Tab
                label="Города"
                value="city"
                textColor="primary"
                classes={{
                  label: classnames(classes.button, 'Wrapless'),
                  labelContainer: classes.tabButton,
                  wrapper: classes.tabButton,
                  selected: classes.bc,
                  root: classes.rootTabPrimary
                }}
              /> */}
            </Tabs>
          </AppBar>
          <TabContainer>
            {section === "item" && <Item />}
            {/* {section === "city" && <City />} */}
          </TabContainer>
        </section>
        {/* <Footer /> */}
      </div>
    )
  }
}

//export default withStyles(styles)(TrainingPlansPage)

export default connect(
  state => ({ 
    items: state.item.items
  }),
  dispatch => ({
    getItemsForPortfolio: () => {
      dispatch(getItemsForPortfolio())
    }
  })
)(withStyles(styles)(ItemPage)) //(withRouter(withStyles(styles)(ItemPage)))