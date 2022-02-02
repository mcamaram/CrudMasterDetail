using AlbumMasterDetail.Models;
using AlbumMasterDetail.Service;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlbumMasterDetail
{
    public partial class Form1 : Form
    {
        private Album _album;
        private IAlbumService _albumService;
        public Form1()
        {
            InitializeComponent();
            //(new AlbumMasterDetail.DropShadow()).ApplyShadows(this);
            //(new Core.DropShadow()).ApplyShadows(this);
            _album = new Album();
            _albumService = new AlbumService();
        }
        private void AddSong()
        {
            Song song = new Song();

            song.Name = txtNameSong.Text;
            song.Minutes = txtMinutes.Text != string.Empty ? int.Parse(txtMinutes.Text) : 0;

            if (_album.Songs == null)
            {
                _album.Songs = new List<Song>();
            }
            _album.Songs.Add(song);
        }
        private void ClearSong()
        {
            txtNameSong.Text = "";
            txtMinutes.Text = "";
        }

        private void SaveAlbum()
        {
            _album.Name = txtAlbumName.Text;
            _album.Author = txtAuthor.Text;
            _album.RealeseDate = dtpReleaseDate.Value;

            _albumService.SaveAlbum(_album);
        }

        private void ClearAlbum()
        {
            txtAlbumName.Text = "";
            txtAuthor.Text = "";
            dtpReleaseDate.Value = DateTime.Now;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            AddSong();
            dgvSongs.AutoGenerateColumns = false;
            BindingSource bs = new BindingSource();
            bs.DataSource = _album.Songs;
            dgvSongs.DataSource = bs;
            ClearSong();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveAlbum();
            ClearAlbum();
        }
    }
}
