import {
  Button, Image, ListGroup
} from 'react-bootstrap';
import classes from './SideBar.module.css';
import logo from '../../assets/boologo.png'
import { useNavigate } from "react-router";

function SideBar() {
  const navigate = useNavigate();
  return (
    <div className={classes.sidebar}>
      <Image src={logo} className={classes.logo} />
      <div className="d-grid gap-0">
      <Button variant="outline-success" size="sm" onClick={() =>{navigate('/')}}>Tổng quan</Button>
      <Button variant="outline-success" size="sm" onClick={() =>{navigate('/product')}}>Sản phẩm</Button>
      <Button variant="outline-success" size="sm" onClick={() =>{navigate('/category')}}>Danh mục</Button>
      <Button variant="outline-success" size="sm" onClick={() =>{navigate('/subcategory')}}>Danh mục con</Button>
      </div>
    </div>
  );
};

export default SideBar;
