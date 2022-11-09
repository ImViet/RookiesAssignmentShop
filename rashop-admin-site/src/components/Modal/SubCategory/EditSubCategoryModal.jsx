import { Modal, Button } from "react-bootstrap";
import EditSubCategoryForm from "../../Form/SubCategory/EditSubCategoryForm";
import { putSubCategoryAPI } from "../../../api/SubCategory";

function EditSubCategoryModal({status, onClose, data}) {
  const handleSubmit = (category)=>{
    putSubCategoryAPI(category).then(()=>{
      onClose();
      setTimeout(() => {
        alert("Sửa thành công!!!");
      }, 200);
    }).catch((err)=>{
      setTimeout(() => {
        alert("Sửa thất bại!!!");
      }, 200);
      console.log(err)});
  }
  return (
    <Modal show={status}>
      <Modal.Header>
        <Modal.Title>Sửa danh mục</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        <EditSubCategoryForm data={data} onSubmit={handleSubmit}/>
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
    </Modal>
  );
}
export default EditSubCategoryModal;
