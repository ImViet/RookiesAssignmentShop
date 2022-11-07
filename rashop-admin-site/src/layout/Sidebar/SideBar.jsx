import {
  Image,
} from 'react-bootstrap';
import {
  MDBBtn,
} from "mdb-react-ui-kit";

import classes from './SideBar.module.css';
import logo from '../../assets/boologo.png'
import { useNavigate } from "react-router";

function SideBar() {
  const navigate = useNavigate();
  return (
    <div className={classes.sidebar}>
      <Image src={logo} className={classes.logo} />
      <div className="d-grid gap-0 mt-3">
      <MDBBtn outline color='success' className='text-light mt-1' onClick={() =>{navigate('/product')}}>
        Sản phẩm
      </MDBBtn>
      <MDBBtn outline color='success' className='text-light mt-1' onClick={() =>{navigate('/category')}}>
        Danh mục
      </MDBBtn>
      <MDBBtn outline color='success' className='text-light mt-1' onClick={() =>{navigate('/subcategory')}}>
        Danh mục con
      </MDBBtn>
      </div>
    </div>
  );
};

export default SideBar;
