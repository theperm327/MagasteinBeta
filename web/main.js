const scene = new THREE.Scene();
const camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 1000);
const renderer = new THREE.WebGLRenderer({ antialias: true });
renderer.setSize(window.innerWidth, window.innerHeight);
document.body.appendChild(renderer.domElement);

const blocks = [];
const gridSize = 8;
for (let x = 0; x < gridSize; x++) {
  for (let z = 0; z < gridSize; z++) {
    const geometry = new THREE.BoxGeometry(1, 1, 1);
    const material = new THREE.MeshStandardMaterial({ color: 0x666666 });
    const cube = new THREE.Mesh(geometry, material);
    cube.position.set(x - gridSize / 2, 0, z - gridSize / 2);
    scene.add(cube);
    blocks.push(cube);
  }
}

const light = new THREE.DirectionalLight(0xffffff, 0.8);
light.position.set(0, 10, 10);
scene.add(light);

camera.position.set(0, 5, 10);
camera.lookAt(0, 0, 0);

const raycaster = new THREE.Raycaster();
const mouse = new THREE.Vector2();
let highlighted = null;

function onMove(event) {
  mouse.x = (event.clientX / window.innerWidth) * 2 - 1;
  mouse.y = -(event.clientY / window.innerHeight) * 2 + 1;
  raycaster.setFromCamera(mouse, camera);
  const intersects = raycaster.intersectObjects(blocks);
  if (intersects.length > 0) {
    const obj = intersects[0].object;
    if (highlighted && highlighted !== obj) {
      highlighted.material.emissive.set(0x000000);
    }
    highlighted = obj;
    highlighted.material.emissive.set(0x3333ff);
  } else {
    if (highlighted) highlighted.material.emissive.set(0x000000);
    highlighted = null;
  }
}
window.addEventListener('mousemove', onMove);

function animate() {
  requestAnimationFrame(animate);
  renderer.render(scene, camera);
}
animate();

window.addEventListener('resize', () => {
  camera.aspect = window.innerWidth / window.innerHeight;
  camera.updateProjectionMatrix();
  renderer.setSize(window.innerWidth, window.innerHeight);
});
